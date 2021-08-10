using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class StreetBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימה 
        public static List<StreetEntities> GetAllStreet()
        {
            List<Street> S = bl.Street.ToList();
            return StreetEntities.ConvertToListStreetEntities(S);
        }

        //פונקציה השולפת רחוב לפי קוד
        public static StreetEntities GetIdStreet(int id)
        {
            Street S1 = bl.Street.FirstOrDefault(x => x.StreetID == id);
            return StreetEntities.ConvertStreetTableToStreetEntities(S1);
        }

        //פונקצית המוסיפה רחוב חדש
        public static List<StreetEntities> GetAddStreet(StreetEntities S)
        {
            bl.Street.Add(StreetEntities.ConvertStreetEntitiesToStreetTable(S));
            bl.SaveChanges();
            return StreetEntities.ConvertToListStreetEntities(bl.Street.ToList());
        }

        //פונקציה המעדכנת רחוב מהרשימה
        public static List<StreetEntities> GetUpdatStreet(StreetEntities S)
        {
            bl.Street.FirstOrDefault(x => x.StreetID == S.StreetID).StreetName = S.StreetName;
            bl.SaveChanges();
            return StreetEntities.ConvertToListStreetEntities(bl.Street.ToList());
        }

        //פונקציה המסירה רחוב מהרשימה
        public static List<StreetEntities> GetRemoveStreet(int id)
        {
            var listStreet = bl.Street.Where(x => x.StreetID == id);
            foreach (var item in listStreet)
            {
                bl.Street.Remove(item);
            }
            bl.Street.Remove(bl.Street.FirstOrDefault(x => x.StreetID == id));
            bl.SaveChanges();
            return StreetEntities.ConvertToListStreetEntities(bl.Street.ToList());
        }
    }
}
