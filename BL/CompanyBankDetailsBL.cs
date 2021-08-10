using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class CompanyBankDetailsBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימה 
        public static List<CompanyBankDetailsEntities> GetAllCompanyBankDetails()
        {
            List<CompanyBankDetails> CBD = bl.CompanyBankDetails.ToList();
            return CompanyBankDetailsEntities.ConvertToListCompanyBankDetailsEntities(CBD);
        }

        //פונקציה השולפת פרטי בנק לפי קוד
        public static CompanyBankDetailsEntities GetIdCompanyBankDetails(int id)
        {
            CompanyBankDetails CBD1 = bl.CompanyBankDetails.FirstOrDefault(x => x.SendingCompanyID == id);
            return CompanyBankDetailsEntities.ConvertCompanyBankDetailsTableToCompanyBankDetailsEntities(CBD1);
        }

        //פונקצית המוסיפה פרטי בנק חדשה
        public static List<CompanyBankDetailsEntities> GetAddCompanyBankDetails(CompanyBankDetailsEntities CBD)
        {
            bl.CompanyBankDetails.Add(CompanyBankDetailsEntities.ConvertCompanyBankDetailsEntitiesToCompanyBankDetailsTable(CBD));
            bl.SaveChanges();
            return CompanyBankDetailsEntities.ConvertToListCompanyBankDetailsEntities(bl.CompanyBankDetails.ToList());
        }

        //פונקציה המעדכנת פרטי בנק מהרשימה
        public static List<CompanyBankDetailsEntities> GetUpdatCompanyBankDetails(CompanyBankDetailsEntities CBD)
        {
            //bl.CompanyBankDetails.FirstOrDefault(x => x.CompanyBankDetailsID == CBD.CompanyBankDetailsID).SendingCompanyID = CBD.SendingCompanyID;
            bl.CompanyBankDetails.FirstOrDefault(x => x.SendingCompanyID == CBD.SendingCompanyID).BeneficiaryName = CBD.BeneficiaryName;
            bl.CompanyBankDetails.FirstOrDefault(x => x.SendingCompanyID == CBD.SendingCompanyID).Bank = CBD.Bank;
            bl.CompanyBankDetails.FirstOrDefault(x => x.SendingCompanyID == CBD.SendingCompanyID).Branch = CBD.Branch;
            bl.CompanyBankDetails.FirstOrDefault(x => x.SendingCompanyID == CBD.SendingCompanyID).AccountNumber = CBD.AccountNumber;
            bl.SaveChanges();
            return CompanyBankDetailsEntities.ConvertToListCompanyBankDetailsEntities(bl.CompanyBankDetails.ToList());
        }

        //פונקציה המסירה פרטי בנק מהרשימה
        public static List<CompanyBankDetailsEntities> GetRemoveCompanyBankDetails(int id)
        {
            var listCompanyBankDetails = bl.CompanyBankDetails.Where(x => x.CompanyBankDetailsID == id);
            foreach (var item in listCompanyBankDetails)
            {
                bl.CompanyBankDetails.Remove(item);
            }
            bl.CompanyBankDetails.Remove(bl.CompanyBankDetails.FirstOrDefault(x => x.CompanyBankDetailsID == id));
            bl.SaveChanges();
            return CompanyBankDetailsEntities.ConvertToListCompanyBankDetailsEntities(bl.CompanyBankDetails.ToList());
        }
    }
}
