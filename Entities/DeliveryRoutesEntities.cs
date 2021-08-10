using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DeliveryRoutesEntities
    {
        public int DeliveryRoutesID { get; set; }
        public int SendingCompanyID { get; set; }
        public System.DateTime Date { get; set; }
        
        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static DeliveryRoutesEntities ConvertDeliveryRoutesTableToDeliveryRoutesEntities(DeliveryRoutes DR)
        {
            DeliveryRoutesEntities DR1 = new DeliveryRoutesEntities() { DeliveryRoutesID = DR.DeliveryRoutesID, SendingCompanyID = DR.SendingCompanyID, Date = DR.Date };
            return DR1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static DeliveryRoutes ConvertDeliveryRoutesEntitiesToDeliveryRoutesTable(DeliveryRoutesEntities DR)
        {
            DeliveryRoutes DR2 = new DeliveryRoutes() { DeliveryRoutesID = DR.DeliveryRoutesID, SendingCompanyID = DR.SendingCompanyID,Date = DR.Date };
            return DR2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<DeliveryRoutesEntities> ConvertToListDeliveryRoutesEntities(List<DeliveryRoutes> ListDR)
        {
            List<DeliveryRoutesEntities> ListDR1 = new List<DeliveryRoutesEntities>();
            foreach (var item in ListDR)
            {
                ListDR1.Add(ConvertDeliveryRoutesTableToDeliveryRoutesEntities(item));
            }
            return ListDR1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<DeliveryRoutes> ConvertToListDeliveryRoutesTable(List<DeliveryRoutesEntities> ListDR)
        {
            List<DeliveryRoutes> ListDR2 = new List<DeliveryRoutes>();
            foreach (var item in ListDR)
            {
                ListDR2.Add(ConvertDeliveryRoutesEntitiesToDeliveryRoutesTable(item));
            }
            return ListDR2;
        }
    }
}
