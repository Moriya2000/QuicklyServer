using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class DeliveryTypeBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימה
        public static List<DeliveryTypeEntities> GetAllDeliveryType()
        {
            List<DeliveryType> DT = bl.DeliveryType.ToList();
            return DeliveryTypeEntities.ConvertToListDeliveryTypeEntities(DT);
        }

        //פונקציה השולפת סוג משלוח לפי קוד
        public static DeliveryTypeEntities GetIdDeliveryType(int id)
        {
            DeliveryType DT1 = bl.DeliveryType.FirstOrDefault(x => x.DeliveryTypeID == id);
            return DeliveryTypeEntities.ConvertDeliveryTypeTableToDeliveryTypeEntities(DT1);
        }

        //פונקצית המוסיפה סוג משלוח חדש
        public static List<DeliveryTypeEntities> GetAddDeliveryType(DeliveryTypeEntities DT)
        {
            bl.DeliveryType.Add(DeliveryTypeEntities.ConvertDeliveryTypeEntitiesToDeliveryTypeTable(DT));
            bl.SaveChanges();
            return DeliveryTypeEntities.ConvertToListDeliveryTypeEntities(bl.DeliveryType.ToList());
        }

        //פונקציה המעדכנת סוג משלוח מהרשימה
        public static List<DeliveryTypeEntities> GetUpdatDeliveryType(DeliveryTypeEntities DT)
        {
            bl.DeliveryType.FirstOrDefault(x => x.DeliveryTypeID == DT.DeliveryTypeID).DeliveryTypeName = DT.DeliveryTypeName;
            bl.SaveChanges();
            return DeliveryTypeEntities.ConvertToListDeliveryTypeEntities(bl.DeliveryType.ToList());
        }

        //פונקציה המסירה סוג משלוח מהרשימה
        public static List<DeliveryTypeEntities> GetRemoveDeliveryType(int id)
        {
            var listDeliveryType = bl.DeliveryType.Where(x => x.DeliveryTypeID == id);
            foreach (var item in listDeliveryType)
            {
                bl.DeliveryType.Remove(item);
            }
            bl.DeliveryType.Remove(bl.DeliveryType.FirstOrDefault(x => x.DeliveryTypeID == id));
            bl.SaveChanges();
            return DeliveryTypeEntities.ConvertToListDeliveryTypeEntities(bl.DeliveryType.ToList());
        }
    }
}
