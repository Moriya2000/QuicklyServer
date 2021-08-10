using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderEntities
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int DeliveryTypeID { get; set; }
        public int Amount { get; set; }
        public double Volume { get; set; }
        public int DeliveryUrgencyID { get; set; }
        public double FinalPay { get; set; }
        public string Note { get; set; }
        public bool SentOrNot { get; set; }

       
        public TakingDeliveryEntities CityTaking { get; set; }
        public GivingDeliveryEntities CityGiving { get; set; }
        public int Days { get; set; }
        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static OrderEntities ConvertOrderTableToOrderEntities(Order O)
        {

            OrderEntities O1 = new OrderEntities() { OrderID = O.OrderID, ClientID = O.ClientID, OrderDate = O.OrderDate, DeliveryTypeID = O.DeliveryTypeID, Amount = O.Amount, Volume = O.Volume, DeliveryUrgencyID = O.DeliveryUrgencyID, FinalPay = O.FinalPay, Note = O.Note, SentOrNot = O.SentOrNot};
            if (O.TakingDelivery != null && O.TakingDelivery.Count!=0)
                O1.CityTaking = TakingDeliveryEntities.ConvertTakingDeliveryTableToTakingDeliveryEntities( O.TakingDelivery.ToList()[0]);
           if (O.GivingDelivery != null && O.GivingDelivery.Count!=0)
                O1.CityGiving =GivingDeliveryEntities.ConvertGivingDeliveryTableToGivingDeliveryEntities( O.GivingDelivery.FirstOrDefault(c => c != null));
            if (O.DeliveryUrgency != null )
              O1.Days = O.DeliveryUrgency.Urgency;
            return O1;
        }
        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static Order ConvertOrderEntitiesToOrderTable(OrderEntities O)
        {
            Order O2 = new Order() { OrderID = O.OrderID, ClientID = O.ClientID, OrderDate = O.OrderDate, DeliveryTypeID = O.DeliveryTypeID, Amount = O.Amount, Volume = O.Volume, DeliveryUrgencyID = O.DeliveryUrgencyID, FinalPay = O.FinalPay, Note = O.Note, SentOrNot=O.SentOrNot };
            return O2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<OrderEntities> ConvertToListOrderEntities(List<Order> ListO)
        {
            List<OrderEntities> ListO1 = new List<OrderEntities>();
            foreach (var item in ListO)
            {
                OrderEntities order = ConvertOrderTableToOrderEntities(item);
           
                ListO1.Add(order);

            }
            return ListO1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<Order> ConvertToListOrderTable(List<OrderEntities> ListO)
        {
            List<Order> ListO2 = new List<Order>();
            foreach (var item in ListO)
            {
                ListO2.Add(ConvertOrderEntitiesToOrderTable(item));
            }
            return ListO2;
        }
    }
}
