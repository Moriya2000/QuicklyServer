using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class GivingDeliveryEntities
    {
        public int GivingDeliveryID { get; set; }
        public int OrderID { get; set; }
        public int CityID { get; set; }
        public int StreetID { get; set; }
        public Nullable<int> BuildingNumber { get; set; }
        public string EntranceBuilding { get; set; }
        public string FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AdditionalPhone { get; set; }
        public string Email { get; set; }
        public System.TimeSpan PickUpTime { get; set; }
        public System.TimeSpan PickUpTimeUntil { get; set; }
        public Nullable<double> latAddress { get; set; }
        public Nullable<double> lngaddress { get; set; }
        public string NameAddress { get; set; }

        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static GivingDeliveryEntities ConvertGivingDeliveryTableToGivingDeliveryEntities(GivingDelivery GD)
        {
            GivingDeliveryEntities GD1 = new GivingDeliveryEntities() { GivingDeliveryID = GD.GivingDeliveryID, OrderID = GD.OrderID, CityID = GD.CityID, StreetID = GD.StreetID, BuildingNumber = GD.BuildingNumber, EntranceBuilding = GD.EntranceBuilding, FloorNumber = GD.FloorNumber, ApartmentNumber = GD.ApartmentNumber, FirstName = GD.FirstName, LastName = GD.LastName, Phone = GD.Phone, AdditionalPhone = GD.AdditionalPhone, Email = GD.Email, PickUpTime = GD.PickUpTime, PickUpTimeUntil = GD.PickUpTimeUntil , latAddress = GD.latAddress, lngaddress = GD.lngaddress, NameAddress = GD.NameAddress };
            return GD1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static GivingDelivery ConvertGivingDeliveryEntitiesToGivingDeliveryTable(GivingDeliveryEntities GD)
        {
            GivingDelivery GD2 = new GivingDelivery() { GivingDeliveryID = GD.GivingDeliveryID, OrderID = GD.OrderID, CityID = GD.CityID, StreetID = GD.StreetID, BuildingNumber = GD.BuildingNumber, EntranceBuilding = GD.EntranceBuilding, FloorNumber = GD.FloorNumber, ApartmentNumber = GD.ApartmentNumber, FirstName = GD.FirstName, LastName = GD.LastName, Phone = GD.Phone, AdditionalPhone = GD.AdditionalPhone, Email = GD.Email, PickUpTime = GD.PickUpTime, PickUpTimeUntil = GD.PickUpTimeUntil , latAddress = GD.latAddress, lngaddress = GD.lngaddress, NameAddress = GD.NameAddress };
            return GD2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<GivingDeliveryEntities> ConvertToListGivingDeliveryEntities(List<GivingDelivery> ListGD)
        {
            List<GivingDeliveryEntities> ListGD1 = new List<GivingDeliveryEntities>();
            foreach (var item in ListGD)
            {
                ListGD1.Add(ConvertGivingDeliveryTableToGivingDeliveryEntities(item));
            }
            return ListGD1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<GivingDelivery> ConvertToListGivingDeliveryTable(List<GivingDeliveryEntities> ListGD)
        {
            List<GivingDelivery> ListGD2 = new List<GivingDelivery>();
            foreach (var item in ListGD)
            {
                ListGD2.Add(ConvertGivingDeliveryEntitiesToGivingDeliveryTable(item));
            }
            return ListGD2;
        }
    }
}
