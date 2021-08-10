using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StreetEntities
    {
        public int StreetID { get; set; }
        public string StreetName { get; set; }

        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static StreetEntities ConvertStreetTableToStreetEntities(Street S)
        {
            StreetEntities S1 = new StreetEntities() { StreetID = S.StreetID, StreetName = S.StreetName };
            return S1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static Street ConvertStreetEntitiesToStreetTable(StreetEntities S)
        {
            Street S2 = new Street() { StreetID = S.StreetID, StreetName = S.StreetName };
            return S2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<StreetEntities> ConvertToListStreetEntities(List<Street> ListS)
        {
            List<StreetEntities> ListS1 = new List<StreetEntities>();
            foreach (var item in ListS)
            {
                ListS1.Add(ConvertStreetTableToStreetEntities(item));
            }
            return ListS1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<Street> ConvertToListSendingCompanyTable(List<StreetEntities> ListS)
        {
            List<Street> ListS2 = new List<Street>();
            foreach (var item in ListS)
            {
                ListS2.Add(ConvertStreetEntitiesToStreetTable(item));
            }
            return ListS2;
        }
    }
}
