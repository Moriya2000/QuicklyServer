using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using Entities;

namespace BL
{
    public class BusinessDaysBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימה
        public static List<BusinessDaysEntities> GetAllDays()
        {
            List<BusinessDays> BD = bl.BusinessDays.Include(b=>b.SendingCompany).ToList();
            return BusinessDaysEntities.ConvertToListBusinessDaysEntities(BD);
        }

        //פונקציה השולפת יום לפי קוד
        public static List<BusinessDaysEntities> GetIdBusinessDays(int id)
        {
            List<BusinessDays> listBusinessDaysId = bl.BusinessDays.Where(x => x.SendingCompanyID == id).ToList();
            return BusinessDaysEntities.ConvertToListBusinessDaysEntities(listBusinessDaysId);
        }

        //פונקצית המוסיפה יום חדש
        public static List<BusinessDaysEntities> GetAddDay(BusinessDaysEntities BD)
        {

            bl.BusinessDays.Add(BusinessDaysEntities.ConvertBusinessDaysEntitiesToBusinessDaysTable(BD));
            bl.SaveChanges();
            return BusinessDaysEntities.ConvertToListBusinessDaysEntities(bl.BusinessDays.ToList());
        }

        //פונקציה המעדכנת יום מהרשימה
        public static List<BusinessDaysEntities> GetUpdatDay(BusinessDaysEntities BD)
        {
            //bl.BusinessDays.FirstOrDefault(x => x.BusinessDaysID == BD.BusinessDaysID).SendingCompanyID = BD.SendingCompanyID;
            bl.BusinessDays.FirstOrDefault(x => x.BusinessDaysID == BD.BusinessDaysID).Day = BD.Day;
            //bl.BusinessDays.FirstOrDefault(x => x.BusinessDaysID == BD.BusinessDaysID).BeginningTime = BD.BeginningTime;
            //bl.BusinessDays.FirstOrDefault(x => x.BusinessDaysID == BD.BusinessDaysID).EndTime = BD.EndTime;
            bl.SaveChanges();
            return BusinessDaysEntities.ConvertToListBusinessDaysEntities(bl.BusinessDays.ToList());
        }

        //פונקציה המסירה יום מהרשימה
        public static List<BusinessDaysEntities> GetRemoveDay(int id)
        {
            var listBusinessDays = bl.BusinessDays.Where(x => x.BusinessDaysID == id);
            foreach (var item in listBusinessDays)
            {
                bl.BusinessDays.Remove(item);
            }
            bl.BusinessDays.Remove(bl.BusinessDays.FirstOrDefault(x => x.BusinessDaysID == id));
            bl.SaveChanges();
            return BusinessDaysEntities.ConvertToListBusinessDaysEntities(bl.BusinessDays.ToList());
        }
    }
}
