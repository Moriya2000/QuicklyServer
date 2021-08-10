using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class CarsCompanyEntities
    {
        public int CarsCompanyID { get; set; }
        public int SendingCompanyID { get; set; }
        public int CarTypeID { get; set; }
        public Nullable<double> MaxVolume { get; set; }


        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static CarsCompanyEntities ConvertCarsCompanyTableToCarsCompanyEntities(CarsCampany CC)
        {
            CarsCompanyEntities CC1 = new CarsCompanyEntities() { CarsCompanyID = CC.CarsCompanyID, SendingCompanyID = CC.SendingCompanyID, CarTypeID = CC.CarTypeID, MaxVolume =CC.MaxVolume };
            return CC1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static CarsCampany ConvertCarsCompanyEntitiesToCarsCompanyTable(CarsCompanyEntities CC)
        {
            CarsCampany CC2 = new CarsCampany() { CarsCompanyID = CC.CarsCompanyID, SendingCompanyID = CC.SendingCompanyID, CarTypeID = CC.CarTypeID , MaxVolume =CC.MaxVolume };
            return CC2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<CarsCompanyEntities> ConvertToListCarsCompanyEntities(List<CarsCampany> ListCC)
        {
            List<CarsCompanyEntities> ListCC1 = new List<CarsCompanyEntities>();
            foreach (var item in ListCC)
            {
                ListCC1.Add(ConvertCarsCompanyTableToCarsCompanyEntities(item));
            }
            return ListCC1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<CarsCampany> ConvertToListBusinessDaysTable(List<CarsCompanyEntities> ListCC)
        {
            List<CarsCampany> ListCC2 = new List<CarsCampany>();
            foreach (var item in ListCC)
            {
                ListCC2.Add(ConvertCarsCompanyEntitiesToCarsCompanyTable(item));
            }
            return ListCC2;
        }
    }
}
