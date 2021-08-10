using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class CarsTypesBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימה
        public static List<CarsTypesEntities> GetAllCarsTypes()
        {
            List<CarsTypes> CT = bl.CarsTypes.ToList();
            return CarsTypesEntities.ConvertToListCarsTypesEntities(CT);
        }

        //פונקציה השולפת רכב לפי קוד
        public static CarsTypesEntities GetIdCarsTypes(int id)
        {
            CarsTypes CT1 = bl.CarsTypes.FirstOrDefault(x => x.CarTypeID == id);
            return CarsTypesEntities.ConvertCarsTypesTableToCarsTypesEntities(CT1);
        }

        //פונקצית המוסיפה רכב חדש
        public static List<CarsTypesEntities> GetAddCarsTypes(CarsTypesEntities CT)
        {
            bl.CarsTypes.Add(CarsTypesEntities.ConvertCarsTypesEntitiesToCarsTypesTable(CT));
            bl.SaveChanges();
            return CarsTypesEntities.ConvertToListCarsTypesEntities(bl.CarsTypes.ToList());
        }

        //פונקציה המעדכנת רכב מהרשימה
        public static List<CarsTypesEntities> GetUpdatCarsTypes(CarsTypesEntities CT)
        {
            bl.CarsTypes.FirstOrDefault(x => x.CarTypeID == CT.CarTypeID).CarTypeName = CT.CarTypeName;
            bl.SaveChanges();
            return CarsTypesEntities.ConvertToListCarsTypesEntities(bl.CarsTypes.ToList());
        }

        //פונקציה המסירה רכב מהרשימה
        public static List<CarsTypesEntities> GetRemoveCarsTypes(int id)
        {
            var listCarsTypes = bl.CarsTypes.Where(x => x.CarTypeID == id);
            foreach (var item in listCarsTypes)
            {
                bl.CarsTypes.Remove(item);
            }
            bl.CarsTypes.Remove(bl.CarsTypes.FirstOrDefault(x => x.CarTypeID == id));
            bl.SaveChanges();
            return CarsTypesEntities.ConvertToListCarsTypesEntities(bl.CarsTypes.ToList());
        }
    }
}
