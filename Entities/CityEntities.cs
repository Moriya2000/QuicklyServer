using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CityEntities
    {
        public int CityID { get; set; }
        public string CityName { get; set; }


        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static CityEntities ConvertCityTableToCityEntities(City C)
        {
            CityEntities C1 = new CityEntities() { CityID = C.CityID, CityName = C.CityName };
            return C1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static City ConvertCityEntitiesToCityTable(CityEntities C)
        {
            City C2 = new City() { CityID = C.CityID, CityName = C.CityName };
            return C2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<CityEntities> ConvertToListCityEntities(List<City> ListC)
        {
            List<CityEntities> ListC1 = new List<CityEntities>();
            foreach (var item in ListC)
            {
                ListC1.Add(ConvertCityTableToCityEntities(item));
            }
            return ListC1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<City> ConvertToListCityTable(List<CityEntities> ListC)
        {
            List<City> ListC2 = new List<City>();
            foreach (var item in ListC)
            {
                ListC2.Add(ConvertCityEntitiesToCityTable(item));
            }
            return ListC2;
        }
    }
}
