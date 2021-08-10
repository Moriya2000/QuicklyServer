using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using Entities;

namespace BL
{
    public class OrderBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימה
        public static List<OrderEntities> GetAllOrder()
        {
            List<Order> O = bl.Order.Include(t=>t.TakingDelivery).Include(t=>t.GivingDelivery).Include(u=>u.DeliveryUrgency).ToList();
            return OrderEntities.ConvertToListOrderEntities(O);
        }

        //פונקציה השולפת הזמנה לפי קוד
        public static OrderEntities GetIdOrder(int id)
        {
            Order O1= bl.Order.FirstOrDefault(x => x.OrderID == id);
            return OrderEntities.ConvertOrderTableToOrderEntities(O1);
        }

        //פונקצייה ששולפת את כל ההזמנות לפי קוד מסוים
        public static List<OrderEntities> GetAllIdOrder(int id)
        {
            var listOrder = bl.Order.Where(x => x.ClientID == id);
            return OrderEntities.ConvertToListOrderEntities(listOrder.ToList());
        }


        //פונקצית המוסיפה הזמנה חדשה
        public static List<OrderEntities> GetAddOrder(OrderEntities O)
        {
            //bl.Order.Add(OrderEntities.ConvertOrderEntitiesToOrderTable(O));
            //Order O2 = new Order() { OrderID = 1, ClientID = 1, OrderDate = new DateTime(), DeliveryTypeID = 1, Amount = 4, Volume = 3, DeliveryUrgencyID = 3, FinalPay = 1, Note ="fdsf"};
            Order O2 = new Order() { OrderID = O.OrderID, ClientID = O.ClientID, OrderDate = O.OrderDate, DeliveryTypeID = O.DeliveryTypeID, Amount = O.Amount, Volume = O.Volume, DeliveryUrgencyID = O.DeliveryUrgencyID, FinalPay = O.FinalPay, Note = O.Note };

            bl.Order.Add(O2);
            bl.SaveChanges();
            return OrderEntities.ConvertToListOrderEntities(bl.Order.ToList());
        }

        //פונקציה המעדכנת הזמנה מהרשימה
        public static List<OrderEntities> GetUpdatOrder(OrderEntities O)
        {
            bl.Order.FirstOrDefault(x => x.OrderID == O.OrderID).ClientID = O.ClientID;
            bl.Order.FirstOrDefault(x => x.OrderID == O.OrderID).OrderDate = O.OrderDate;
            bl.Order.FirstOrDefault(x => x.OrderID == O.OrderID).DeliveryTypeID = O.DeliveryTypeID;
            bl.Order.FirstOrDefault(x => x.OrderID == O.OrderID).Amount = O.Amount;
            bl.Order.FirstOrDefault(x => x.OrderID == O.OrderID).Volume = O.Volume;
            bl.Order.FirstOrDefault(x => x.OrderID == O.OrderID).DeliveryUrgencyID = O.DeliveryUrgencyID;
            bl.Order.FirstOrDefault(x => x.OrderID == O.OrderID).FinalPay = O.FinalPay;
            bl.Order.FirstOrDefault(x => x.OrderID == O.OrderID).Note = O.Note;
            bl.Order.FirstOrDefault(x => x.OrderID == O.OrderID).SentOrNot = O.SentOrNot;

            bl.SaveChanges();
            return OrderEntities.ConvertToListOrderEntities(bl.Order.ToList());
        }

        //פונקציה המסירה הזמנה מהרשימה
        public static List<OrderEntities> GetRemoveOrder(int id)
        {
            var listOrder = bl.Order.Where(x => x.OrderID == id);
            foreach (var item in listOrder)
            {
                bl.Order.Remove(item);
            }
            bl.Order.Remove(bl.Order.FirstOrDefault(x => x.OrderID == id));
            bl.SaveChanges();
            return OrderEntities.ConvertToListOrderEntities(bl.Order.ToList());
        }

        //פונקצייה המחשבת באיזה מצב נמצא המשלוח
        public static int GetOrderTrack(int id)
        {
            DateTime date;
            DateTime currentTime = DateTime.Now;
            var currentDate = currentTime.Date;
            int urgency;
            int orderTrack;
            Order order= bl.Order.FirstOrDefault(x => x.OrderID == id);
            date = order.OrderDate;
            DeliveryUrgency deliveryUrgency=bl.DeliveryUrgency.FirstOrDefault(x => x.DeliveryUrgencyID==order.DeliveryUrgencyID);
            urgency = deliveryUrgency.Urgency;
            var dateAddUrgency=date.AddDays(urgency);
            if (dateAddUrgency == currentDate)
            {
                orderTrack = 2;
            }
            else
            {
                if (dateAddUrgency > currentDate)
                {
                    orderTrack = 1;
                }
                else
                {
                    orderTrack = 3;
                }
            }
            return orderTrack;
        }
    }
}
