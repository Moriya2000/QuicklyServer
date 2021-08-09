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
    [RoutePrefix("api/SendingCompany")]
    public class SendingCompanyController : ApiController
    {
        //פונקציה השולפת רשימת חברות שליחויות
        [Route("GatAllSendingCompany")]
        [HttpGet]
        public List<SendingCompanyEntities> GetAllSendingCompany()
        {
            return SendingCompanyBL.GetAllSendingCompany();
        }

        //פונקציה השולפת את כל הפרטים של החברת שליחויות על פי קוד
        [Route("GetIdAllDetailsCompany/{id}")]
        [HttpGet]
        public IHttpActionResult GetIdAllDetailsCompany(int id)
        {
          return  Ok(SendingCompanyBL.GetIdAllDetailsCompany(id));
        }

        //פונקציה השולפת חברת שליחויות על פי קוד
        [Route("GetIdSendingCompany/{id}")]
        [HttpGet]
        public SendingCompanyEntities GetIdSendingCompany(int id)
        {
            return SendingCompanyBL.GetIdSendingCompany(id);
        }


        //פונקציה המוסיפה את כל פרטי חברת השליחויות
        [Route("GetAddAllDetailsCompany")]
        [HttpPut]
        public void GetAddAllDetailsCompany([FromBody] AllDetailsCompany C)
        {
            SendingCompanyBL.GetAddAllDetailsCompany(C);
        }
        
        [Route("Scheduling")]
        [HttpGet]
        public IHttpActionResult Scheduling()
        
        {
           return Ok(SendingCompanyBL.Scheduling());
        }
        
        //פונקציה המוסיפה חברת שליחויות
        [Route("GetAddSendingCompany")]
        [HttpPut]
        public List<SendingCompanyEntities> GetAddSendingCompany([FromBody] SendingCompanyEntities C)
        {
            return SendingCompanyBL.GetAddSendingCompany(C);
        }

        //פונקציה המעדכנת חברת שליחויות שקיימת
        [Route("GetUpdatSendingCompany")]
        [HttpPost]
        public List<SendingCompanyEntities> GetUpdatSendingCompany([FromBody] SendingCompanyEntities C)
        {
            return SendingCompanyBL.GetUpdatSendingCompany(C);
        }

        //פונקציה המעדכנת חברת שליחויות שקיימת
        [Route("GetUpdatSendingCompany1")]
        [HttpPost]
        public void GetUpdatSendingCompany1([FromBody] AllDetailsCompany C)
        {
            SendingCompanyBL.GetUpdatSendingCompany1(C);
        }

        //פונקציה שמוחקת חברת שליחויות שקיימת
        [Route("GetRemoveSendingCompany/{id}")]
        [HttpDelete]
        public List<SendingCompanyEntities> GetRemoveSendingCompany(int id)
        {
            return SendingCompanyBL.GetRemoveSendingCompany(id);
        }


        //פונקציה הבודקת אם חברה קיימת
        [Route("GetCompanyNumberPassword/{CompanyNumber}/{Password}")]
        [HttpGet]
        public int GetCompanyNumberPassword(int CompanyNumber, string Password)
        {
            return SendingCompanyBL.GetCompanyNumberPassword(CompanyNumber, Password);
        }


        // [Route("GatAllSendingCompanyByNumberPassword/{CompanyNumber}/{Password}")]
        //[HttpGet]
        //public SendingCompanyEntities GatAllSendingCompanyByNumberPassword(int CompanyNumber, string Password)
        //{
        //    return SendingCompanyBL.GatAllSendingCompanyByNumberPassword(CompanyNumber, Password);
        //}

        [Route("GatAllSendingCompanyByNumberPassword/{sendingCompanyID}")]
        [HttpGet]
        public SendingCompanyEntities GatAllSendingCompanyByNumberPassword(int sendingCompanyID)
        {
            return SendingCompanyBL.GatAllSendingCompanyByNumberPassword(sendingCompanyID);
        }
    }
}
