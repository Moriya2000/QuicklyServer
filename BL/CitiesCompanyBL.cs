using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class CitiesCompanyBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימת ערים בהם החברה עובדת
        public static List<CitiesCompanyEntities> GetAllCitiesCompany()
        {
            List<CitiesCompany> CC = bl.CitiesCompany.ToList();
            return CitiesCompanyEntities.ConvertToListCitiesCompanyEntities(CC);
        }

        //פונקציה השולפת עיר שהחברה עובדת לפי קוד
        public static List<CitiesCompanyEntities> GetIdCitiesCompany(int id)
        {
            var l = bl.CitiesCompany.ToList();
            List <CitiesCompany> CC1 = bl.CitiesCompany.Where(x => x.SendingCompanyID == id).ToList();
           
            return CitiesCompanyEntities.ConvertToListCitiesCompanyEntities(CC1);
        }

        //פונקצית המוסיפה עיר שבה החברה עובדת
        public static List<CitiesCompanyEntities> GetAddCitiesCompany(CitiesCompanyEntities CC)
        {
            bl.CitiesCompany.Add(CitiesCompanyEntities.ConvertCitiesCompanyEntitiesToCitiesCompanyTable(CC));
            bl.SaveChanges();
            return CitiesCompanyEntities.ConvertToListCitiesCompanyEntities(bl.CitiesCompany.ToList());
        }

        //פונקציה המעדכנת עיר שבה החברה עובדת
        public static List<CitiesCompanyEntities> GetUpdatCitiesCompany(CitiesCompanyEntities CC)
        {
            //bl.CitiesCompany.FirstOrDefault(x => x.SendingCompanyID == CC.SendingCompanyID).SendingCompanyID = CC.SendingCompanyID;
            bl.CitiesCompany.FirstOrDefault(x => x.CitiesCompanyID == CC.CitiesCompanyID).CityID = CC.CityID;
            bl.SaveChanges();
            return CitiesCompanyEntities.ConvertToListCitiesCompanyEntities(bl.CitiesCompany.ToList());
        }

        //פונקציה המסירה עיר שהחברה עובדת בה
        public static List<CitiesCompanyEntities> GetRemoveCitiesCompany(int id)
        {
            var listCitiesCompany = bl.CitiesCompany.Where(x => x.CitiesCompanyID == id);
            foreach (var item in listCitiesCompany)
            {
                bl.CitiesCompany.Remove(item);
            }
            bl.CitiesCompany.Remove(bl.CitiesCompany.FirstOrDefault(x => x.CitiesCompanyID == id));
            bl.SaveChanges();
            return CitiesCompanyEntities.ConvertToListCitiesCompanyEntities(bl.CitiesCompany.ToList());
        }
    }
}
