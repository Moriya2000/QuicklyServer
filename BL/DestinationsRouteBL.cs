using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class DestinationsRouteBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        public static List<DestinationsRouteEntities> GetDestinationsRoute()
        {
            List<DestinationsRoute> DR = bl.DestinationsRoute.ToList();
            return DestinationsRouteEntities.ConvertToListDestinationsRouteEntities(DR);
        }

        //פונקציה השולפת רשימה
        public static List<DestinationsRouteEntities> GetAllDestinationsRoute(int idDelveryRoute)
        {
            List<DestinationsRoute> DR = bl.DestinationsRoute.Where(x=>x.DeliveryRoutesID==idDelveryRoute).ToList();
            return DestinationsRouteEntities.ConvertToListDestinationsRouteEntities(DR);
        }


        //פונקציה השולפת יעד במסלול לפי קוד
        public static List<int> GetIdDestinationsRoute(int id)
        {
            try
            {
                int count = 0;
                List<DestinationsRoute> DR1 = new List<DestinationsRoute>();
                List<DeliveryRoutes> listOrder = bl.DeliveryRoutes.Where(x => x.SendingCompanyID == id).ToList();
                List<int> listCount = new List<int>();

                foreach (var item in listOrder)
                {
                    DR1 = bl.DestinationsRoute.Where(x => x.DeliveryRoutesID == item.DeliveryRoutesID).ToList();
                    foreach (var i in DR1)
                    {
                        count++;
                    }
                    listCount.Add(count);
                    count = 0;
                }
                return listCount;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        //public static List<double> GetIdDestinationsRouteForSum(int id)
        //{
        //    try
        //    { 
        //    double sum = 0;
        //    Order order;
        //    List<DeliveryRoutes> listOrder = bl.DeliveryRoutes.Where(x => x.SendingCompanyID == id).ToList();
        //    List<DestinationsRoute> listAllOrder = new List<DestinationsRoute>();
        //    List<Order> listDelivery = new List<Order>();
        //    List<double> listSum = new List<double>();

        //    foreach (var item in listOrder)
        //    {
        //        listAllOrder = bl.DestinationsRoute.Where(x => x.DeliveryRoutesID == item.DeliveryRoutesID).ToList();
        //        foreach (var item1 in listAllOrder)
        //        {
        //            order = bl.Order.FirstOrDefault(x => x.OrderID == item1.OrderID);
        //            listDelivery.Add(order);

        //        }
        //        foreach (var item2 in listDelivery)
        //        {
        //            sum += item2.FinalPay;
        //        }
        //        listSum.Add(sum);
        //        sum = 0;
        //        listDelivery = new List<Order>();

        //    }
        //    return listSum;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        //פונקצית המוסיפה יעד במסלול חדש
        public static List<DestinationsRouteEntities> GetAddDestinationsRoute(DestinationsRouteEntities DR)
        {
            bl.DestinationsRoute.Add(DestinationsRouteEntities.ConvertDestinationsRouteEntitiesToDestinationsRouteTable(DR));
            bl.SaveChanges();
            return DestinationsRouteEntities.ConvertToListDestinationsRouteEntities(bl.DestinationsRoute.ToList());
        }

        //פונקציה המעדכנת יעד במסלול מהרשימה
        public static List<DestinationsRouteEntities> GetUpdatDestinationsRoute(DestinationsRouteEntities DR)
        {
            bl.DestinationsRoute.FirstOrDefault(x => x.DestinationsRouteID == DR.DestinationsRouteID).OrderID = DR.OrderID;

            bl.SaveChanges();
            return DestinationsRouteEntities.ConvertToListDestinationsRouteEntities(bl.DestinationsRoute.ToList());
        }

        //פונקציה המסירה יעד במסלול מהרשימה
        public static List<DestinationsRouteEntities> GetRemoveDestinationsRoute(int id)
        {
            var listDestinationsRoute = bl.DestinationsRoute.Where(x => x.DestinationsRouteID == id);
            foreach (var item in listDestinationsRoute)
            {
                bl.DestinationsRoute.Remove(item);
            }
            bl.DestinationsRoute.Remove(bl.DestinationsRoute.FirstOrDefault(x => x.DestinationsRouteID == id));
            bl.SaveChanges();
            return DestinationsRouteEntities.ConvertToListDestinationsRouteEntities(bl.DestinationsRoute.ToList());
        }

    }
}
