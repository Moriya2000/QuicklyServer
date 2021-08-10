using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TakingDeliveryEntities
    {
        public int TakingDeliveryID { get; set; }
        public int OrderID { get; set; }
        public int CityID { get; set; }
        public int StreetID { get; set; }
        public Nullable<int> BuildingNumber { get; set; }
        public Nullable<int> EntranceBuilding { get; set; }
        public Nullable<int> FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AdditionalPhone { get; set; }
        public string Email { get; set; }
        public System.TimeSpan PickUpTime { get; set; }
        public System.TimeSpan PickUpTimeUntil { get; set; }
        public Nullable<double> latAddress { get; set; }
        public Nullable<double> lngAddress { get; set; }
        public string NameAddress { get; set; }
    


     //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
     public static TakingDeliveryEntities ConvertTakingDeliveryTableToTakingDeliveryEntities(TakingDelivery TD)
        {
            if (TD == null)
                return null;
            TakingDeliveryEntities TD1 = new TakingDeliveryEntities() { TakingDeliveryID = TD.TakingDeliveryID, OrderID = TD.OrderID, CityID = TD.CityID, StreetID = TD.StreetID, BuildingNumber = TD.BuildingNumber, EntranceBuilding = TD.EntranceBuilding, FloorNumber = TD.FloorNumber, ApartmentNumber = TD.ApartmentNumber, FirstName = TD.FirstName, LastName = TD.LastName, Phone = TD.Phone, AdditionalPhone = TD.AdditionalPhone, Email = TD.Email, PickUpTime = TD.PickUpTime, PickUpTimeUntil = TD.PickUpTimeUntil, latAddress =TD.latAddress, lngAddress=TD.lngAddress, NameAddress=TD.NameAddress };
            return TD1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static TakingDelivery ConvertTakingDeliveryEntitiesToTakingDeliveryTable(TakingDeliveryEntities TD)
        {
            TakingDelivery TD2 = new TakingDelivery() { TakingDeliveryID = TD.TakingDeliveryID, OrderID = TD.OrderID, CityID = TD.CityID, StreetID = TD.StreetID, BuildingNumber = TD.BuildingNumber, EntranceBuilding = TD.EntranceBuilding, FloorNumber = TD.FloorNumber, ApartmentNumber = TD.ApartmentNumber, FirstName = TD.FirstName, LastName = TD.LastName, Phone = TD.Phone, AdditionalPhone = TD.AdditionalPhone, Email = TD.Email, PickUpTime = TD.PickUpTime, PickUpTimeUntil = TD.PickUpTimeUntil, latAddress = TD.latAddress, lngAddress = TD.lngAddress, NameAddress = TD.NameAddress };
            return TD2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<TakingDeliveryEntities> ConvertToListTakingDeliveryEntities(List<TakingDelivery> ListTD)
        {
            List<TakingDeliveryEntities> ListTD1 = new List<TakingDeliveryEntities>();
            foreach (var item in ListTD)
            {
                ListTD1.Add(ConvertTakingDeliveryTableToTakingDeliveryEntities(item));
            }
            return ListTD1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<TakingDelivery> ConvertToListTakingDeliveryTable(List<TakingDeliveryEntities> ListTD)
        {
            List<TakingDelivery> ListTD2 = new List<TakingDelivery>();
            foreach (var item in ListTD)
            {
                ListTD2.Add(ConvertTakingDeliveryEntitiesToTakingDeliveryTable(item));
            }
            return ListTD2;
        }
    }
}
