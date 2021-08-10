using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SendingCompanyEntities
    {
        public int SendingCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string FullAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CompanyNumber { get; set; }
        public string Password { get; set; }
        public List<List<OrderEntities>> lo = new List<List<OrderEntities>>();
        public CarsCompanyEntities car { get; set; }


        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static SendingCompanyEntities ConvertSendingCompanyTableToSendingCompanyEntities(SendingCompany SC)
        {
            SendingCompanyEntities SC1 = new SendingCompanyEntities() { SendingCompanyID = SC.SendingCompanyID, CompanyName = SC.CompanyName, FullAddress=SC.FullAddress, Phone = SC.Phone, Email = SC.Email, CompanyNumber = SC.CompanyNumber, Password = SC.Password };
            return SC1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static SendingCompany ConvertSendingCompanyEntitiesToSendingCompanyTable(SendingCompanyEntities SC)
        {
            SendingCompany SC2 = new SendingCompany() { SendingCompanyID = SC.SendingCompanyID, CompanyName = SC.CompanyName, FullAddress = SC.FullAddress, Phone = SC.Phone, Email = SC.Email, CompanyNumber = SC.CompanyNumber, Password = SC.Password };
            return SC2;
        }   
        
        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<SendingCompanyEntities> ConvertToListSendingCompanyEntities(List<SendingCompany> ListSC)
        {
            List<SendingCompanyEntities> ListSC1 = new List<SendingCompanyEntities>();
            foreach (var item in ListSC)
            {
                ListSC1.Add(ConvertSendingCompanyTableToSendingCompanyEntities(item));
            }
            return ListSC1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<SendingCompany> ConvertToListSendingCompanyTable(List<SendingCompanyEntities> ListSC)
        {
            List<SendingCompany> ListSC2 = new List<SendingCompany>();
            foreach (var item in ListSC)
            {
                ListSC2.Add(ConvertSendingCompanyEntitiesToSendingCompanyTable(item));
            }
            return ListSC2;
        }
    }
}
