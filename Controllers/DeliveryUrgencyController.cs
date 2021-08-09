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
    [RoutePrefix("api/DeliveryUrgency")]
    public class DeliveryUrgencyController : ApiController
    {
        //פונקציה השולפת רשימת דחיפויות משלוח
        [Route("GatAllDeliveryUrgency")]
        [HttpGet]
        public List<DeliveryUrgencyEntities> GetAllDeliveryUrgency()
        {
            return DeliveryUrgencyBL.GetAllDeliveryUrgency();
        }

        //פונקציה השולפת דחיפות משלוח על פי קוד
        [Route("GetIdDeliveryUrgency/{id}")]
        [HttpGet]
        public DeliveryUrgencyEntities GetIdDeliveryUrgency(int id)
        {
            return DeliveryUrgencyBL.GetIdDeliveryUrgency(id);
        }

        //פונקציה המוסיפה דחיפות משלוח
        [Route("GetAddDeliveryUrgency")]
        [HttpPut]
        public List<DeliveryUrgencyEntities> GetAddDeliveryUrgency([FromBody] DeliveryUrgencyEntities C)
        {
            return DeliveryUrgencyBL.GetAddDeliveryUrgency(C);
        }

        //פונקציה המעדכנת דחיפות משלוח שקיים
        [Route("GetUpdatDeliveryUrgency")]
        [HttpPost]
        public List<DeliveryUrgencyEntities> GetUpdatDeliveryUrgency([FromBody] DeliveryUrgencyEntities C)
        {
            return DeliveryUrgencyBL.GetUpdatDeliveryUrgency(C);
        }

        //פונקציה שמוחקת דחיפות משלוח שקיים
        [Route("GetRemoveDeliveryUrgency/{id}")]
        [HttpDelete]
        public List<DeliveryUrgencyEntities> GetRemoveDeliveryUrgency(int id)
        {
            return DeliveryUrgencyBL.GetRemoveDeliveryUrgency(id);
        }
    }
}
