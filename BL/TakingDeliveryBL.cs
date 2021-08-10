using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class TakingDeliveryBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימה
        public static List<TakingDeliveryEntities> GetAllTakingDelivery()
        {
            List<TakingDelivery> TD = bl.TakingDelivery.ToList();
            return TakingDeliveryEntities.ConvertToListTakingDeliveryEntities(TD);
        }

        //ID פונקציה השולפת את כל פרטי ההזמנה לפי 
        public static AllOrder GetAllOrder(int OrderID)
        {
            AllOrder allOrder = new AllOrder();
            var takingDelivery = GetIdTakingDelivery(OrderID);
            allOrder.TDCityID = takingDelivery.CityID;
            allOrder.TDStreetID = takingDelivery.StreetID;
            allOrder.TDBuildingNumber = takingDelivery.BuildingNumber;
            allOrder.TDEntranceBuilding = takingDelivery.EntranceBuilding;
            allOrder.TDFloorNumber = takingDelivery.FloorNumber;
            allOrder.TDApartmentNumber = takingDelivery.ApartmentNumber;
            allOrder.TDFirstName = takingDelivery.FirstName;
            allOrder.TDLastName = takingDelivery.LastName;
            allOrder.TDPhone = takingDelivery.Phone;
            allOrder.TDAdditionalPhone = takingDelivery.AdditionalPhone;
            allOrder.TDEmail = takingDelivery.Email;
            allOrder.TDPickUpTime = takingDelivery.PickUpTime;
            allOrder.TDPickUpTimeUntil = takingDelivery.PickUpTimeUntil;
            allOrder.TDlatAddress = takingDelivery.latAddress;
            allOrder.TDlngaddress = takingDelivery.lngAddress;
            allOrder.TDNameAddress = takingDelivery.NameAddress;
            allOrder.TakingDeliveryID = takingDelivery.TakingDeliveryID;

            var givingDelivery = GivingDeliveryBL.GetIdGivingDelivery(OrderID);
            allOrder.GDCityID = givingDelivery.CityID;
            allOrder.GDStreetID = givingDelivery.StreetID;
            allOrder.GDBuildingNumber = givingDelivery.BuildingNumber;
            allOrder.GDEntranceBuilding = givingDelivery.EntranceBuilding;
            allOrder.GDFloorNumber = givingDelivery.FloorNumber;
            allOrder.GDApartmentNumber = givingDelivery.ApartmentNumber;
            allOrder.GDFirstName = givingDelivery.FirstName;
            allOrder.GDLastName = givingDelivery.LastName;
            allOrder.GDPhone = givingDelivery.Phone;
            allOrder.GDAdditionalPhone = givingDelivery.AdditionalPhone;
            allOrder.GDEmail = givingDelivery.Email;
            allOrder.GDPickUpTime = givingDelivery.PickUpTime;
            allOrder.GDPickUpTimeUntil = givingDelivery.PickUpTimeUntil;
            allOrder.GDlatAddress = givingDelivery.latAddress;
            allOrder.GDlngAddress = givingDelivery.lngaddress;
            allOrder.GDNameAddress = givingDelivery.NameAddress;
            allOrder.GivingDeliveryID = givingDelivery.GivingDeliveryID;

            var order = OrderBL.GetIdOrder(OrderID);
            allOrder.OrderID = OrderID;
            allOrder.ClientID = order.ClientID;
            allOrder.OrderDate = order.OrderDate;
            allOrder.DeliveryTypeID = order.DeliveryTypeID;
            allOrder.Amount = order.Amount;
            allOrder.Volume = order.Volume;
            allOrder.DeliveryUrgencyID = order.DeliveryUrgencyID;
            allOrder.FinalPay = order.FinalPay;
            allOrder.Note = order.Note;

            return allOrder;
    }
        //פונקציה השולפת לקיחת משלוח לפי קוד
        public static TakingDeliveryEntities GetIdTakingDelivery(int id)
        {
            TakingDelivery TD1 = bl.TakingDelivery.FirstOrDefault(x => x.OrderID == id);
            return TakingDeliveryEntities.ConvertTakingDeliveryTableToTakingDeliveryEntities(TD1);
        }

        //פונקצית המוסיפה לקיחת משלוח חדש
        public static int GetAddAllOrder(AllOrder TD)
        {
            OrderEntities OrderA = new OrderEntities();
            OrderA.OrderID = TD.OrderID;
            OrderA.ClientID = TD.ClientID;
            OrderA.OrderDate = TD.OrderDate;
            OrderA.DeliveryTypeID = TD.DeliveryTypeID;
            OrderA.Amount = TD.Amount;
            OrderA.Volume = TD.Volume;
            OrderA.DeliveryUrgencyID = TD.DeliveryUrgencyID;
            OrderA.FinalPay = TD.FinalPay;
            OrderA.Note = TD.Note;
            
            TakingDeliveryEntities takingDeliveryB = new TakingDeliveryEntities();
            takingDeliveryB.TakingDeliveryID = TD.TakingDeliveryID;
            takingDeliveryB.OrderID = TD.OrderID;
            takingDeliveryB.CityID = TD.TDCityID;
            takingDeliveryB.StreetID = TD.TDStreetID;
            takingDeliveryB.BuildingNumber = TD.TDBuildingNumber;
            takingDeliveryB.EntranceBuilding = TD.TDEntranceBuilding;
            takingDeliveryB.FloorNumber = TD.TDFloorNumber;
            takingDeliveryB.ApartmentNumber = TD.TDApartmentNumber;
            takingDeliveryB.FirstName = TD.TDFirstName;
            takingDeliveryB.LastName = TD.TDLastName;
            takingDeliveryB.Phone = TD.TDPhone;
            takingDeliveryB.AdditionalPhone = TD.TDAdditionalPhone;
            takingDeliveryB.Email = TD.TDEmail;
            takingDeliveryB.PickUpTime = TD.TDPickUpTime;
            takingDeliveryB.PickUpTimeUntil = TD.TDPickUpTimeUntil;
            takingDeliveryB.latAddress = TD.TDlatAddress;
            takingDeliveryB.lngAddress = TD.TDlngaddress;
            takingDeliveryB.NameAddress = TD.TDNameAddress;

            GivingDeliveryEntities givingDeliveryC = new GivingDeliveryEntities();
            givingDeliveryC.GivingDeliveryID = TD.GivingDeliveryID;
            givingDeliveryC.OrderID = TD.OrderID;
            givingDeliveryC.CityID = TD.GDCityID;
            givingDeliveryC.StreetID = TD.GDStreetID;
            givingDeliveryC.BuildingNumber = TD.GDBuildingNumber;
            givingDeliveryC.EntranceBuilding = TD.GDEntranceBuilding;
            givingDeliveryC.FloorNumber = TD.GDFloorNumber;
            givingDeliveryC.ApartmentNumber = TD.GDApartmentNumber;
            givingDeliveryC.FirstName = TD.GDFirstName;
            givingDeliveryC.LastName = TD.GDLastName;
            givingDeliveryC.Phone = TD.GDPhone;
            givingDeliveryC.AdditionalPhone = TD.GDAdditionalPhone;
            givingDeliveryC.Email = TD.GDEmail;
            givingDeliveryC.PickUpTime = TD.GDPickUpTime;
            givingDeliveryC.PickUpTimeUntil = TD.GDPickUpTimeUntil;
            givingDeliveryC.latAddress = TD.GDlatAddress;
            givingDeliveryC.lngaddress = TD.GDlngAddress;
            givingDeliveryC.NameAddress = TD.GDNameAddress;

            int id  = OrderBL.GetAddOrder(OrderA).Last().OrderID;
            
            givingDeliveryC.OrderID = id;
            takingDeliveryB.OrderID = id;

            GivingDeliveryBL.GetAddGivingDelivery(givingDeliveryC);
            GetAddTakingDelivery(takingDeliveryB);
            return id;
        }

        public static List<TakingDeliveryEntities> GetAddTakingDelivery(TakingDeliveryEntities TD)
        {
            bl.TakingDelivery.Add(TakingDeliveryEntities.ConvertTakingDeliveryEntitiesToTakingDeliveryTable(TD));
            bl.SaveChanges();
            return TakingDeliveryEntities.ConvertToListTakingDeliveryEntities(bl.TakingDelivery.ToList());
        }
        public static void GetUpdatAllOrder(AllOrder TD)
        {
            OrderEntities OrderA = new OrderEntities();
            OrderA.OrderID = TD.OrderID;
            OrderA.ClientID = TD.ClientID;
            OrderA.OrderDate = TD.OrderDate;
            OrderA.DeliveryTypeID = TD.DeliveryTypeID;
            OrderA.Amount = TD.Amount;
            OrderA.Volume = TD.Volume;
            OrderA.DeliveryUrgencyID = TD.DeliveryUrgencyID;
            OrderA.FinalPay = TD.FinalPay;
            OrderA.Note = TD.Note;

            TakingDeliveryEntities takingDeliveryB = new TakingDeliveryEntities();
            takingDeliveryB.TakingDeliveryID = TD.TakingDeliveryID;
            takingDeliveryB.OrderID = TD.OrderID;
            takingDeliveryB.CityID = TD.TDCityID;
            takingDeliveryB.StreetID = TD.TDStreetID;
            takingDeliveryB.BuildingNumber = TD.TDBuildingNumber;
            takingDeliveryB.EntranceBuilding = TD.TDEntranceBuilding;
            takingDeliveryB.FloorNumber = TD.TDFloorNumber;
            takingDeliveryB.ApartmentNumber = TD.TDApartmentNumber;
            takingDeliveryB.FirstName = TD.TDFirstName;
            takingDeliveryB.LastName = TD.TDLastName;
            takingDeliveryB.Phone = TD.TDPhone;
            takingDeliveryB.AdditionalPhone = TD.TDAdditionalPhone;
            takingDeliveryB.Email = TD.TDEmail;
            takingDeliveryB.PickUpTime = TD.TDPickUpTime;
            takingDeliveryB.PickUpTimeUntil = TD.TDPickUpTimeUntil;
            takingDeliveryB.latAddress = TD.TDlatAddress;
            takingDeliveryB.lngAddress = TD.TDlngaddress;
            takingDeliveryB.NameAddress = TD.TDNameAddress;

            GivingDeliveryEntities givingDeliveryC = new GivingDeliveryEntities();
            givingDeliveryC.GivingDeliveryID = TD.GivingDeliveryID;
            givingDeliveryC.OrderID = TD.OrderID;
            givingDeliveryC.CityID = TD.GDCityID;
            givingDeliveryC.StreetID = TD.GDStreetID;
            givingDeliveryC.BuildingNumber = TD.GDBuildingNumber;
            givingDeliveryC.EntranceBuilding = TD.GDEntranceBuilding;
            givingDeliveryC.FloorNumber = TD.GDFloorNumber;
            givingDeliveryC.ApartmentNumber = TD.GDApartmentNumber;
            givingDeliveryC.FirstName = TD.GDFirstName;
            givingDeliveryC.LastName = TD.GDLastName;
            givingDeliveryC.Phone = TD.GDPhone;
            givingDeliveryC.AdditionalPhone = TD.GDAdditionalPhone;
            givingDeliveryC.Email = TD.GDEmail;
            givingDeliveryC.PickUpTime = TD.GDPickUpTime;
            givingDeliveryC.PickUpTimeUntil = TD.GDPickUpTimeUntil;
            givingDeliveryC.latAddress = TD.GDlatAddress;
            givingDeliveryC.lngaddress = TD.GDlngAddress;
            givingDeliveryC.NameAddress = TD.GDNameAddress;

            int id = OrderBL.GetUpdatOrder(OrderA).Last().OrderID;

            givingDeliveryC.OrderID = id;
            takingDeliveryB.OrderID = id;

            GivingDeliveryBL.GetUpdatGivingDelivery(givingDeliveryC);
            GetUpdatTakingDelivery(takingDeliveryB);
        }
        //פונקציה המעדכנת לקיחת משלוח מהרשימה
        public static List<TakingDeliveryEntities> GetUpdatTakingDelivery(TakingDeliveryEntities TD)
        {
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).OrderID = TD.OrderID;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).CityID = TD.CityID;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).StreetID = TD.StreetID;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).BuildingNumber = TD.BuildingNumber;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).EntranceBuilding = TD.EntranceBuilding;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).FloorNumber = TD.FloorNumber;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).ApartmentNumber = TD.ApartmentNumber;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).FirstName = TD.FirstName;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).LastName = TD.LastName;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).Phone = TD.Phone;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).AdditionalPhone = TD.AdditionalPhone;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).Email = TD.Email;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).PickUpTime = TD.PickUpTime;
            bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == TD.TakingDeliveryID).PickUpTimeUntil = TD.PickUpTimeUntil;
            bl.SaveChanges();
            return TakingDeliveryEntities.ConvertToListTakingDeliveryEntities(bl.TakingDelivery.ToList());
        }

        //פונקציה המסירה לקיחת משלוח מהרשימה
        public static List<TakingDeliveryEntities> GetRemoveTakingDelivery(int id)
        {
            var listTakingDelivery = bl.TakingDelivery.Where(x => x.TakingDeliveryID == id);
            foreach (var item in listTakingDelivery)
            {
                bl.TakingDelivery.Remove(item);
            }
            bl.TakingDelivery.Remove(bl.TakingDelivery.FirstOrDefault(x => x.TakingDeliveryID == id));
            bl.SaveChanges();
            return TakingDeliveryEntities.ConvertToListTakingDeliveryEntities(bl.TakingDelivery.ToList());
        }


        public static string GetAddressMailByOrderID(int orderID)
        {
            try
            {
              var taking=  bl.TakingDelivery.FirstOrDefault(g => g.OrderID == orderID);
                return taking.Email;
            }
            catch(Exception e)
            {
                return "";
            }
          
        }
    }
}
