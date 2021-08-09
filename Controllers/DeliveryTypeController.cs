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
    [RoutePrefix("api/DeliveryType")]
    public class DeliveryTypeController : ApiController
    {
        //פונקציה השולפת סוגי משלוח
        [Route("GatAllDeliveryType")]
        [HttpGet]
        public List<DeliveryTypeEntities> GetAllDeliveryType()
        {
            return DeliveryTypeBL.GetAllDeliveryType();
        }

        //פונקציה השולפת סוג משלוח על פי קוד
        [Route("GetIdDeliveryType/{id}")]
        [HttpGet]
        public DeliveryTypeEntities GetIdDeliveryType(int id)
        {
            return DeliveryTypeBL.GetIdDeliveryType(id);
        }

        //פונקציה המוסיפה סוג משלוח
        [Route("GetAddDeliveryType")]
        [HttpPut]
        public List<DeliveryTypeEntities> GetAddDeliveryType([FromBody] DeliveryTypeEntities C)
        {
            return DeliveryTypeBL.GetAddDeliveryType(C);
        }

        //פונקציה המעדכנת סוג משלוח שקיים
        [Route("GetUpdatDeliveryType")]
        [HttpPost]
        public List<DeliveryTypeEntities> GetUpdatDeliveryType([FromBody] DeliveryTypeEntities C)
        {
            return DeliveryTypeBL.GetUpdatDeliveryType(C);
        }

        //פונקציה שמוחקת סוג שקיים
        [Route("GetRemoveDeliveryType/{id}")]
        [HttpDelete]
        public List<DeliveryTypeEntities> GetRemoveDeliveryType(int id)
        {
            return DeliveryTypeBL.GetRemoveDeliveryType(id);
        }
    }
}
