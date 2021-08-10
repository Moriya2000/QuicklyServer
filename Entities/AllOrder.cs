using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AllOrder
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

        
        public int TakingDeliveryID { get; set; }
        public int TDCityID { get; set; }
        public int TDStreetID { get; set; }
        public Nullable<int> TDBuildingNumber { get; set; }
        public Nullable<int> TDEntranceBuilding { get; set; }
        public Nullable<int> TDFloorNumber { get; set; }
        public int TDApartmentNumber { get; set; }
        public string TDFirstName { get; set; }
        public string TDLastName { get; set; }
        public string TDPhone { get; set; }
        public string TDAdditionalPhone { get; set; }
        public string TDEmail { get; set; }
        public System.TimeSpan TDPickUpTime { get; set; }
        public System.TimeSpan TDPickUpTimeUntil { get; set; }
        public Nullable<double> TDlatAddress { get; set; }
        public Nullable<double> TDlngaddress { get; set; }
        public string TDNameAddress { get; set; }


        public int GivingDeliveryID { get; set; }
        public int GDCityID { get; set; }
        public int GDStreetID { get; set; }
        public Nullable<int> GDBuildingNumber { get; set; }
        public string GDEntranceBuilding { get; set; }
        public string GDFloorNumber { get; set; }
        public int GDApartmentNumber { get; set; }
        public string GDFirstName { get; set; }
        public string GDLastName { get; set; }
        public string GDPhone { get; set; }
        public string GDAdditionalPhone { get; set; }
        public string GDEmail { get; set; }
        public System.TimeSpan GDPickUpTime { get; set; }
        public System.TimeSpan GDPickUpTimeUntil { get; set; }
        public Nullable<double> GDlatAddress { get; set; }
        public Nullable<double> GDlngAddress { get; set; }
        public string GDNameAddress { get; set; }
    }
}
