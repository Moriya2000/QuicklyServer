using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class CityBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימה
        public static List<CityEntities> GetAllCity()
        {
            List<City> C = bl.City.ToList();
            return CityEntities.ConvertToListCityEntities(C);
        }

        //פונקציה השולפת עיר לפי קוד
        public static CityEntities GetIdCity(int id)
        {
            City C1 = bl.City.FirstOrDefault(x => x.CityID == id);
            return CityEntities.ConvertCityTableToCityEntities(C1);
        }

        //פונקצית המוסיפה עיר חדשה
        public static List<CityEntities> GetAddCity(CityEntities C)
        {
            bl.City.Add(CityEntities.ConvertCityEntitiesToCityTable(C));
            bl.SaveChanges();
            return CityEntities.ConvertToListCityEntities(bl.City.ToList());
        }

        //פונקציה המעדכנת עיר מהרשימה
        public static List<CityEntities> GetUpdatCity(CityEntities C)
        {
            bl.City.FirstOrDefault(x => x.CityID == C.CityID).CityName = C.CityName;
            bl.SaveChanges();
            return CityEntities.ConvertToListCityEntities(bl.City.ToList());
        }

        //פונקציה המסירה עיר מהרשימה
        public static List<CitiesCompanyEntities> GetRemoveCitiesCompany(int id)
        {
            var listCityCompany = bl.CitiesCompany.Where(x => x.CitiesCompanyID == id);
            foreach (var item in listCityCompany)
            {
                bl.CitiesCompany.Remove(item);
            }
            bl.CitiesCompany.Remove(bl.CitiesCompany.FirstOrDefault(x => x.CitiesCompanyID == id));
            bl.SaveChanges();
            return CitiesCompanyEntities.ConvertToListCitiesCompanyEntities(bl.CitiesCompany.ToList());
        }
    }
}
