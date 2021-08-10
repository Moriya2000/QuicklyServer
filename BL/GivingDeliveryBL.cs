using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class GivingDeliveryBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימה
        public static List<GivingDeliveryEntities> GetAllGivingDelivery()
        {
            List<GivingDelivery> GD = bl.GivingDelivery.ToList();
            return GivingDeliveryEntities.ConvertToListGivingDeliveryEntities(GD);
        }

        //פונקציה השולפת נתינת משלוח לפי קוד
        public static GivingDeliveryEntities GetIdGivingDelivery(int id)
        {
            GivingDelivery GD1 = bl.GivingDelivery.FirstOrDefault(x => x.OrderID == id);
            return GivingDeliveryEntities.ConvertGivingDeliveryTableToGivingDeliveryEntities(GD1);
        }

        //פונקצית המוסיפה נתינת משלוח חדש
        public static List<GivingDeliveryEntities> GetAddGivingDelivery(GivingDeliveryEntities GD)
        {
            bl.GivingDelivery.Add(GivingDeliveryEntities.ConvertGivingDeliveryEntitiesToGivingDeliveryTable(GD));
            bl.SaveChanges();
            return GivingDeliveryEntities.ConvertToListGivingDeliveryEntities(bl.GivingDelivery.ToList());
        }

        //פונקציה המעדכנת נתינת משלוח מהרשימה
        public static List<GivingDeliveryEntities> GetUpdatGivingDelivery(GivingDeliveryEntities GD)
        {
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).OrderID = GD.OrderID;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).CityID = GD.CityID;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).StreetID = GD.StreetID;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).BuildingNumber = GD.BuildingNumber;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).EntranceBuilding = GD.EntranceBuilding;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).FloorNumber = GD.FloorNumber;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).ApartmentNumber = GD.ApartmentNumber;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).FirstName = GD.FirstName;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).LastName = GD.LastName;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).Phone = GD.Phone;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).AdditionalPhone = GD.AdditionalPhone;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).Email = GD.Email;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).PickUpTime = GD.PickUpTime;
            bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == GD.GivingDeliveryID).PickUpTimeUntil = GD.PickUpTimeUntil;
            bl.SaveChanges();
            return GivingDeliveryEntities.ConvertToListGivingDeliveryEntities(bl.GivingDelivery.ToList());
        }

        //פונקציה המסירה נתינת משלוח מהרשימה
        public static List<GivingDeliveryEntities> GetRemoveGivingDelivery(int id)
        {
            var listGivingDelivery = bl.GivingDelivery.Where(x => x.GivingDeliveryID == id);
            foreach (var item in listGivingDelivery)
            {
                bl.GivingDelivery.Remove(item);
            }
            bl.GivingDelivery.Remove(bl.GivingDelivery.FirstOrDefault(x => x.GivingDeliveryID == id));
            bl.SaveChanges();
            return GivingDeliveryEntities.ConvertToListGivingDeliveryEntities(bl.GivingDelivery.ToList());
        }


        public static string GetAddressMailByOrderID(int orderID)
        {
            try
            {
                var giving = bl.GivingDelivery.FirstOrDefault(g => g.OrderID == orderID);
                return giving.Email;
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
