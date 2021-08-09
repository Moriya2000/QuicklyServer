using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using Entities;

namespace QuicklyServer.Controllers
{
    [RoutePrefix("api/CompanyBankDetails")]
    public class CompanyBankDetailsController : ApiController
    {
        //פונקציה השולפת רשימת פרטי בנק חברה
        [Route("GatAllCompanyBankDetails")]
        [HttpGet]
        public List<CompanyBankDetailsEntities> GetAllCompanyBankDetails()
        {
            return CompanyBankDetailsBL.GetAllCompanyBankDetails();
        }

        //פונקציה השולפת פרטי בנק חברה על פי קוד
        [Route("GetIdCompanyBankDetails/{id}")]
        [HttpGet]
        public CompanyBankDetailsEntities GetIdCompanyBankDetails(int id)
        {
            return CompanyBankDetailsBL.GetIdCompanyBankDetails(id);
        }

        //פונקציה המוסיפה פרטי בנק חברה
        [Route("GetAddCompanyBankDetails")]
        [HttpPut]
        public List<CompanyBankDetailsEntities> GetAddCompanyBankDetails([FromBody] CompanyBankDetailsEntities C)
        {
            return CompanyBankDetailsBL.GetAddCompanyBankDetails(C);
        }

        //פונקציה המעדכנת פרטי בנק חברה הקיימים
        [Route("GetUpdatCompanyBankDetails")]
        [HttpPost]
        public List<CompanyBankDetailsEntities> GetUpdatCompanyBankDetails([FromBody] CompanyBankDetailsEntities C)
        {
            return CompanyBankDetailsBL.GetUpdatCompanyBankDetails(C);
        }

        //פונקציה שמוחקת פרטי בנק חברה הקיימים
        [Route("GetRemoveCompanyBankDetails/{id}")]
        [HttpDelete]
        public List<CompanyBankDetailsEntities> GetRemoveCompanyBankDetails(int id)
        {
            return CompanyBankDetailsBL.GetRemoveCompanyBankDetails(id);
        }
    }
}
