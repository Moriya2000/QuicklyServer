using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AllDetailsCompany
    {
        //פרטים אישיים
        public int SendingCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string FullAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CompanyNumber { get; set; }
        public string Password { get; set; }
            
        //ימי עבודה
        public List<BusinessDaysEntities> listBusinessDays { get; set; }

  

        //פרטי בנק
        public int CompanyBankDetailsID { get; set; }
        public string BeneficiaryName { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }

        //ערים שהחברה עובדת בהם
        public List<CitiesCompanyEntities> listCitiesCompany { get; set; }

        //רכבים שיש לחברה
        public List<CarsCompanyEntities> listCarsCompany { get; set; }
    }
}
