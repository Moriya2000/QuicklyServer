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
    [RoutePrefix("api/DeliveryRoutes")]
    public class DeliveryRoutesController : ApiController
    {
        //פונקציה השולפת רשימת מסלולי משלוחים
        [Route("GatAllDeliveryRoutes")]
        [HttpGet]
        public List<DeliveryRoutesEntities> GetAllDeliveryRoutes()
        {
            return DeliveryRoutesBL.GetAllDeliveryRoutes();
        }

        //פונקציה השולפת מסלול משלוח על פי קוד
        [Route("GetIdDeliveryRoutes/{id}")]
        [HttpGet]
        public DeliveryRoutesEntities GetIdDeliveryRoutes(int id)
        {
            return DeliveryRoutesBL.GetIdDeliveryRoutes(id);
        }

        //פונקציה המוסיפה מסלול משלוח
        [Route("GetAddDeliveryRoutes")]
        [HttpPut]
        public List<DeliveryRoutesEntities> GetAddDeliveryRoutes([FromBody] DeliveryRoutesEntities C)
        {
            return DeliveryRoutesBL.GetAddDeliveryRoutes(C);
        }

        //פונקציה המעדכנת מסלול משלוח קיים
        [Route("GetUpdatDeliveryRoutes")]
        [HttpPost]
        public List<DeliveryRoutesEntities> GetUpdatDeliveryRoutes([FromBody] DeliveryRoutesEntities C)
        {
            return DeliveryRoutesBL.GetUpdatDeliveryRoutes(C);
        }

        //פונקציה שמוחקת מסלול משלוח קיים
        [Route("GetRemoveDeliveryRoutes/{id}")]
        [HttpDelete]
        public List<DeliveryRoutesEntities> GetRemoveDeliveryRoutes(int id)
        {
            return DeliveryRoutesBL.GetRemoveDeliveryRoutes(id);
        }
    }
}
