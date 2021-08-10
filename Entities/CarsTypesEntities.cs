using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CarsTypesEntities
    {
        public int CarTypeID { get; set; }
        public string CarTypeName { get; set; }


        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static CarsTypesEntities ConvertCarsTypesTableToCarsTypesEntities(CarsTypes CT)
        {
            CarsTypesEntities CT1 = new CarsTypesEntities() { CarTypeID = CT.CarTypeID, CarTypeName = CT.CarTypeName };
            return CT1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static CarsTypes ConvertCarsTypesEntitiesToCarsTypesTable(CarsTypesEntities CT)
        {
            CarsTypes CT2 = new CarsTypes() { CarTypeID = CT.CarTypeID, CarTypeName = CT.CarTypeName };
            return CT2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<CarsTypesEntities> ConvertToListCarsTypesEntities(List<CarsTypes> ListCT)
        {
            List<CarsTypesEntities> ListCT1 = new List<CarsTypesEntities>();
            foreach (var item in ListCT)
            {
                ListCT1.Add(ConvertCarsTypesTableToCarsTypesEntities(item));
            }
            return ListCT1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<CarsTypes> ConvertToListCarsTypesTable(List<CarsTypesEntities> ListCT)
        {
            List<CarsTypes> ListCT2 = new List<CarsTypes>();
            foreach (var item in ListCT)
            {
                ListCT2.Add(ConvertCarsTypesEntitiesToCarsTypesTable(item));
            }
            return ListCT2;
        }
    }
}
