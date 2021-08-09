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

        //פונקציה השולפת חברת שליחויות על פי קוד
        [Route("GetIdSendingCompany/{id}")]
        [HttpGet]
        public SendingCompanyEntities GetIdSendingCompany(int id)
        {
            return SendingCompanyBL.GetIdSendingCompany(id);
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

        //פונקציה שמוחקת חברת שליחויות שקיימת
        [Route("GetRemoveSendingCompany/{id}")]
        [HttpDelete]
        public List<SendingCompanyEntities> GetRemoveSendingCompany(int id)
        {
            return SendingCompanyBL.GetRemoveSendingCompany(id);
        }
    }
}
