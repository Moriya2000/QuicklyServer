using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class DeliveryUrgencyBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימה
        public static List<DeliveryUrgencyEntities> GetAllDeliveryUrgency()
        {
            List<DeliveryUrgency> DU = bl.DeliveryUrgency.ToList();
            return DeliveryUrgencyEntities.ConvertToListDeliveryUrgencyEntities(DU);
        }

        //פונקציה השולפת דחיפות משלוח לפי קוד
        public static DeliveryUrgencyEntities GetIdDeliveryUrgency(int id)
        {
            DeliveryUrgency DU1 = bl.DeliveryUrgency.FirstOrDefault(x => x.DeliveryUrgencyID == id);
            return DeliveryUrgencyEntities.ConvertDeliveryUrgencyTableToDeliveryUrgencyEntities(DU1);
        }

        //פונקצית המוסיפה דחיפות משלוח חדש
        public static List<DeliveryUrgencyEntities> GetAddDeliveryUrgency(DeliveryUrgencyEntities DU)
        {
            bl.DeliveryUrgency.Add(DeliveryUrgencyEntities.ConvertDeliveryUrgencyEntitiesToDeliveryUrgencyTable(DU));
            bl.SaveChanges();
            return DeliveryUrgencyEntities.ConvertToListDeliveryUrgencyEntities(bl.DeliveryUrgency.ToList());
        }

        //פונקציה המעדכנת דחיפות משלוח מהרשימה
        public static List<DeliveryUrgencyEntities> GetUpdatDeliveryUrgency(DeliveryUrgencyEntities DU)
        {
            bl.DeliveryUrgency.FirstOrDefault(x => x.DeliveryUrgencyID == DU.DeliveryUrgencyID).Urgency = DU.Urgency;
            bl.SaveChanges();
            return DeliveryUrgencyEntities.ConvertToListDeliveryUrgencyEntities(bl.DeliveryUrgency.ToList());
        }

        //פונקציה המסירה דחיפות משלוח מהרשימה
        public static List<DeliveryUrgencyEntities> GetRemoveDeliveryUrgency(int id)
        {
            var listDeliveryUrgency = bl.DeliveryUrgency.Where(x => x.DeliveryUrgencyID == id);
            foreach (var item in listDeliveryUrgency)
            {
                bl.DeliveryUrgency.Remove(item);
            }
            bl.DeliveryUrgency.Remove(bl.DeliveryUrgency.FirstOrDefault(x => x.DeliveryUrgencyID == id));
            bl.SaveChanges();
            return DeliveryUrgencyEntities.ConvertToListDeliveryUrgencyEntities(bl.DeliveryUrgency.ToList());
        }
    }
}
