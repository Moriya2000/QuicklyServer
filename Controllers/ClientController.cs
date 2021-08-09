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
    [RoutePrefix("api/Client")]
    public class ClientController : ApiController
    {
        //פונקציה המוסיפה לקוח
        [Route("GetAddClient")]
        [HttpPut]
        public List<ClientEntities> GetAddClient([FromBody] ClientEntities C)
        {
            return ClientBL.GetAddClient(C);
        }

        //פונקציה השולפת רשימת לקוחות
        [Route("GetAllClient")]
        [HttpGet]
        public List<ClientEntities> GetAllClient()
        {
            return ClientBL.GetAllClient();
        }

        //פונקציה השולפת לקוח על פי קוד
        [Route("GetIdClient/{id}")]
        [HttpGet]
        public ClientEntities GetIdClient(int id)
        {
            return ClientBL.GetIdClient(id);
        }

        //פונקציה המעדכנת פרטי לקוח קיים
        [Route("GetUpdatClient")]
        [HttpPost]
        public List<ClientEntities> GetUpdatClient([FromBody] ClientEntities C)
        {
            return ClientBL.GetUpdatClient(C);
        }

        //פונקציה שמוחקת לקוח קיים
        [Route("GetRemoveClient/{id}")]
        [HttpDelete]
        public List<ClientEntities> GetRemoveClient(int id)
        {
            return ClientBL.GetRemoveClient(id);
        }

        //פונקציה הבודקת אם לקוח קיים
        [Route("GetEmailAddressPassword/{EmailAddress}/{Password}")]
        [HttpGet]
        public int GetEmailAddressPassword(string EmailAddress, string Password)
        {
            return ClientBL.GetEmailAddressPassword(EmailAddress, Password);
        }
    }
}
