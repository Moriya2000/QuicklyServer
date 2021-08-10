using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CitiesCompanyEntities
    {
        public int CitiesCompanyID { get; set; }
        public int SendingCompanyID { get; set; }
        public int CityID { get; set; }
        public string nameCity { get; set; }

        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static CitiesCompanyEntities ConvertCitiesCompanyTableToCitiesCompanyEntities(CitiesCompany CC)
        {
            CitiesCompanyEntities CC1 = new CitiesCompanyEntities() { CitiesCompanyID = CC.CitiesCompanyID, SendingCompanyID = CC.SendingCompanyID, CityID = CC.CityID};
            return CC1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static CitiesCompany ConvertCitiesCompanyEntitiesToCitiesCompanyTable(CitiesCompanyEntities CC)
        {
            CitiesCompany CC2 = new CitiesCompany() { CitiesCompanyID = CC.CitiesCompanyID, SendingCompanyID = CC.SendingCompanyID, CityID = CC.CityID };
            return CC2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<CitiesCompanyEntities> ConvertToListCitiesCompanyEntities(List<CitiesCompany> ListCC)
        {
            List<CitiesCompanyEntities> ListCC1 = new List<CitiesCompanyEntities>();
            foreach (var item in ListCC)
            {
                ListCC1.Add(ConvertCitiesCompanyTableToCitiesCompanyEntities(item));
            }
            return ListCC1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<CitiesCompany> ConvertToListCitiesCompanyTable(List<CitiesCompanyEntities> ListCC)
        {
            List<CitiesCompany> ListCC2 = new List<CitiesCompany>();
            foreach (var item in ListCC)
            {
                ListCC2.Add(ConvertCitiesCompanyEntitiesToCitiesCompanyTable(item));
            }
            return ListCC2;
        }
    }
}
