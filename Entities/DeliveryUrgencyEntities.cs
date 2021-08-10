using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DeliveryUrgencyEntities
    {
        public int DeliveryUrgencyID { get; set; }
        public int Urgency { get; set; }

        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static DeliveryUrgencyEntities ConvertDeliveryUrgencyTableToDeliveryUrgencyEntities(DeliveryUrgency DU)
        {
            DeliveryUrgencyEntities DU1 = new DeliveryUrgencyEntities() { DeliveryUrgencyID = DU.DeliveryUrgencyID, Urgency = DU.Urgency };
            return DU1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static DeliveryUrgency ConvertDeliveryUrgencyEntitiesToDeliveryUrgencyTable(DeliveryUrgencyEntities DU)
        {
            DeliveryUrgency DU2 = new DeliveryUrgency() { DeliveryUrgencyID = DU.DeliveryUrgencyID, Urgency = DU.Urgency };
            return DU2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<DeliveryUrgencyEntities> ConvertToListDeliveryUrgencyEntities(List<DeliveryUrgency> ListDU)
        {
            List<DeliveryUrgencyEntities> ListDU1 = new List<DeliveryUrgencyEntities>();
            foreach (var item in ListDU)
            {
                ListDU1.Add(ConvertDeliveryUrgencyTableToDeliveryUrgencyEntities(item));
            }
            return ListDU1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<DeliveryUrgency> ConvertToListDeliveryUrgencyTable(List<DeliveryUrgencyEntities> ListDU)
        {
            List<DeliveryUrgency> ListDU2 = new List<DeliveryUrgency>();
            foreach (var item in ListDU)
            {
                ListDU2.Add(ConvertDeliveryUrgencyEntitiesToDeliveryUrgencyTable(item));
            }
            return ListDU2;
        }
    }
}
