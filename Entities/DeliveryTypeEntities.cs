using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DeliveryTypeEntities
    {
        public int DeliveryTypeID { get; set; }
        public string DeliveryTypeName { get; set; }

        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static DeliveryTypeEntities ConvertDeliveryTypeTableToDeliveryTypeEntities(DeliveryType DT)
        {
            DeliveryTypeEntities DT1 = new DeliveryTypeEntities() { DeliveryTypeID = DT.DeliveryTypeID, DeliveryTypeName = DT.DeliveryTypeName };
            return DT1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static DeliveryType ConvertDeliveryTypeEntitiesToDeliveryTypeTable(DeliveryTypeEntities DT)
        {
            DeliveryType DT2 = new DeliveryType() { DeliveryTypeID = DT.DeliveryTypeID, DeliveryTypeName = DT.DeliveryTypeName };
            return DT2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<DeliveryTypeEntities> ConvertToListDeliveryTypeEntities(List<DeliveryType> ListDT)
        {
            List<DeliveryTypeEntities> ListDT1 = new List<DeliveryTypeEntities>();
            foreach (var item in ListDT)
            {
                ListDT1.Add(ConvertDeliveryTypeTableToDeliveryTypeEntities(item));
            }
            return ListDT1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<DeliveryType> ConvertToListDeliveryTypeTable(List<DeliveryTypeEntities> ListDT)
        {
            List<DeliveryType> ListDT2 = new List<DeliveryType>();
            foreach (var item in ListDT)
            {
                ListDT2.Add(ConvertDeliveryTypeEntitiesToDeliveryTypeTable(item));
            }
            return ListDT2;
        }
    }
}
