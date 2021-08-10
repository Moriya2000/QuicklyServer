using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class CarsCompanyBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימת רכבים של החברה 
        public static List<CarsCompanyEntities> GetAllCarsCompany()
        {
            List<CarsCampany> CC = bl.CarsCampany.ToList();
            return CarsCompanyEntities.ConvertToListCarsCompanyEntities(CC);
        }

        //פונקציה השולפת רכב של החברה לפי קוד
        public static List<CarsCompanyEntities> GetIdCarsCompany(int id)
        {
            List<CarsCampany> CC1 = bl.CarsCampany.Where(x => x.SendingCompanyID == id).ToList();
           
            return CarsCompanyEntities.ConvertToListCarsCompanyEntities(CC1);
        }

        //פונקצית המוסיפה רכב של החברה 
        public static List<CarsCompanyEntities> GetAddCarsCompany(CarsCompanyEntities CC)
        {
            bl.CarsCampany.Add(CarsCompanyEntities.ConvertCarsCompanyEntitiesToCarsCompanyTable(CC));
            bl.SaveChanges();
            return CarsCompanyEntities.ConvertToListCarsCompanyEntities(bl.CarsCampany.ToList());
        }

        //פונקציה המעדכנת רכב של החברה 
        public static List<CarsCompanyEntities> GetUpdatCarsCompany(CarsCompanyEntities CC)
        {
            //bl.CarsCampany.FirstOrDefault(x => x.SendingCompanyID == CC.SendingCompanyID).SendingCompanyID = CC.SendingCompanyID;
            bl.CarsCampany.FirstOrDefault(x => x.CarsCompanyID == CC.CarsCompanyID).CarTypeID = CC.CarTypeID;
            bl.CarsCampany.FirstOrDefault(x => x.CarsCompanyID == CC.CarsCompanyID).MaxVolume = CC.MaxVolume;
            bl.SaveChanges();
            return CarsCompanyEntities.ConvertToListCarsCompanyEntities(bl.CarsCampany.ToList());
        }

        //פונקציה המסירה רכב של החברה
        public static List<CarsCompanyEntities> GetRemoveCarsCompany(int id)
        {
            var listCarsCompany = bl.CarsCampany.Where(x => x.CarsCompanyID == id);
            foreach (var item in listCarsCompany)
            {
                bl.CarsCampany.Remove(item);
            }
            bl.CarsCampany.Remove(bl.CarsCampany.FirstOrDefault(x => x.CarsCompanyID == id));
            bl.SaveChanges();
            return CarsCompanyEntities.ConvertToListCarsCompanyEntities(bl.CarsCampany.ToList());
        }
    }
}

