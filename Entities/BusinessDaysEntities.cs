using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BusinessDaysEntities
    {
        public int BusinessDaysID { get; set; }
        public int SendingCompanyID { get; set; }
        public int Day { get; set; }
        public System.TimeSpan BeginningTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public SendingCompanyEntities SendingCompany { get; set; }


        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static BusinessDaysEntities ConvertBusinessDaysTableToBusinessDaysEntities(BusinessDays BD)
        {
            BusinessDaysEntities BD1 = new BusinessDaysEntities() { BusinessDaysID=BD.BusinessDaysID, SendingCompanyID = BD.SendingCompanyID, Day = BD.Day, BeginningTime = BD.BeginningTime, EndTime = BD.EndTime };
            if (BD.SendingCompany != null)
                BD1.SendingCompany =SendingCompanyEntities.ConvertSendingCompanyTableToSendingCompanyEntities( BD.SendingCompany);
            return BD1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static BusinessDays ConvertBusinessDaysEntitiesToBusinessDaysTable(BusinessDaysEntities BD)
        {
            BusinessDays BD2 = new BusinessDays() { BusinessDaysID = BD.BusinessDaysID, SendingCompanyID = BD.SendingCompanyID, Day = BD.Day, BeginningTime = BD.BeginningTime, EndTime = BD.EndTime };
            return BD2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<BusinessDaysEntities> ConvertToListBusinessDaysEntities(List<BusinessDays> ListBD)
        {
            List<BusinessDaysEntities> ListBD1 = new List<BusinessDaysEntities>();
            foreach (var item in ListBD)
            {
                ListBD1.Add(ConvertBusinessDaysTableToBusinessDaysEntities(item));
            }
            return ListBD1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<BusinessDays> ConvertToListBusinessDaysTable(List<BusinessDaysEntities> ListBD)
        {
            List<BusinessDays> ListBD2 = new List<BusinessDays>();
            foreach (var item in ListBD)
            {
                ListBD2.Add(ConvertBusinessDaysEntitiesToBusinessDaysTable(item));
            }
            return ListBD2;
        }
    }
}
