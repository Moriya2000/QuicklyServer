using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DestinationsRouteEntities
    {
        public int DestinationsRouteID { get; set; }
        public int OrderID { get; set; }
        public int DeliveryRoutesID { get; set; }

        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static DestinationsRouteEntities ConvertDestinationsRouteTableToDestinationsRouteEntities(DestinationsRoute DR)
        {
            DestinationsRouteEntities DR1 = new DestinationsRouteEntities() { DestinationsRouteID = DR.DestinationsRouteID, OrderID = DR.OrderID, DeliveryRoutesID=DR.DeliveryRoutesID};
            return DR1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static DestinationsRoute ConvertDestinationsRouteEntitiesToDestinationsRouteTable(DestinationsRouteEntities DR)
        {
            DestinationsRoute DR2 = new DestinationsRoute() { DestinationsRouteID = DR.DestinationsRouteID, OrderID = DR.OrderID, DeliveryRoutesID = DR.DeliveryRoutesID };
            return DR2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<DestinationsRouteEntities> ConvertToListDestinationsRouteEntities(List<DestinationsRoute> ListDR)
        {
            List<DestinationsRouteEntities> ListDR1 = new List<DestinationsRouteEntities>();
            foreach (var item in ListDR)
            {
                ListDR1.Add(ConvertDestinationsRouteTableToDestinationsRouteEntities(item));
            }
            return ListDR1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<DestinationsRoute> ConvertToListDestinationsRouteTable(List<DestinationsRouteEntities> ListDR)
        {
            List<DestinationsRoute> ListDR2 = new List<DestinationsRoute>();
            foreach (var item in ListDR)
            {
                ListDR2.Add(ConvertDestinationsRouteEntitiesToDestinationsRouteTable(item));
            }
            return ListDR2;
        }
    }
}
