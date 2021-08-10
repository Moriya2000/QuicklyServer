using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CompanyBankDetailsEntities
    {
        public int CompanyBankDetailsID { get; set; }
        public int SendingCompanyID { get; set; }
        public string BeneficiaryName { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }


        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static CompanyBankDetailsEntities ConvertCompanyBankDetailsTableToCompanyBankDetailsEntities(CompanyBankDetails CBD)
        {
            CompanyBankDetailsEntities CBD1 = new CompanyBankDetailsEntities() { CompanyBankDetailsID= CBD.CompanyBankDetailsID, SendingCompanyID = CBD.SendingCompanyID, BeneficiaryName = CBD.BeneficiaryName, Bank = CBD.Bank, Branch = CBD.Branch, AccountNumber = CBD.AccountNumber };
            return CBD1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static CompanyBankDetails ConvertCompanyBankDetailsEntitiesToCompanyBankDetailsTable(CompanyBankDetailsEntities CBD)
        {
            CompanyBankDetails CBD2 = new CompanyBankDetails() { CompanyBankDetailsID = CBD.CompanyBankDetailsID, SendingCompanyID = CBD.SendingCompanyID, BeneficiaryName = CBD.BeneficiaryName, Bank = CBD.Bank, Branch = CBD.Branch, AccountNumber = CBD.AccountNumber };
            return CBD2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<CompanyBankDetailsEntities> ConvertToListCompanyBankDetailsEntities(List<CompanyBankDetails> ListCBD)
        {
            List<CompanyBankDetailsEntities> ListCBD1 = new List<CompanyBankDetailsEntities>();
            foreach (var item in ListCBD)
            {
                ListCBD1.Add(ConvertCompanyBankDetailsTableToCompanyBankDetailsEntities(item));
            }
            return ListCBD1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<CompanyBankDetails> ConvertToListCompanyBankDetailsTable(List<CompanyBankDetailsEntities> ListCBD)
        {
            List<CompanyBankDetails> ListCBD2 = new List<CompanyBankDetails>();
            foreach (var item in ListCBD)
            {
                ListCBD2.Add(ConvertCompanyBankDetailsEntitiesToCompanyBankDetailsTable(item));
            }
            return ListCBD2;
        }
    }
}
