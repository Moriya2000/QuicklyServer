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
    [RoutePrefix("api/DestinationsRoute")]
    public class DestinationsRouteController : ApiController
    {
        // פונקציה השולפת רשימה
        [Route("GetDestinationsRoute")]
        [HttpGet]
        public List<DestinationsRouteEntities> GetDestinationsRoute()
        {
            return DestinationsRouteBL.GetDestinationsRoute();
        }

        //פונקציה השולפת יעד במסלול על פי קוד
        [Route("GetIdDestinationsRoute/{id}")]
        [HttpGet]
        public List<int> GetIdDestinationsRoute(int id)
        {
            return DestinationsRouteBL.GetIdDestinationsRoute(id);
        }

        //[Route("GetIdDestinationsRouteForSum/{id}")]
        //[HttpGet]
        //public List<double> GetIdDestinationsRouteForSum(int id)
        //{
        //    return DestinationsRouteBL.GetIdDestinationsRouteForSum(id);
        //}

        //פונקציה המוסיפה יעד במסלול
        [Route("GetAddDestinationsRoute")]
        [HttpPut]
        public List<DestinationsRouteEntities> GetAddDestinationsRoute([FromBody] DestinationsRouteEntities C)
        {
            return DestinationsRouteBL.GetAddDestinationsRoute(C);
        }

        //פונקציה המעדכנת יעד במסלול שקיים
        [Route("GetUpdatDestinationsRoute")]
        [HttpPost]
        public List<DestinationsRouteEntities> GetUpdatCity([FromBody] DestinationsRouteEntities C)
        {
            return DestinationsRouteBL.GetUpdatDestinationsRoute(C);
        }

        //פונקציה שמוחקת יעד במסלול שקיים
        [Route("GetRemoveDestinationsRoute/{id}")]
        [HttpDelete]
        public List<DestinationsRouteEntities> GetRemoveDestinationsRoute(int id)
        {
            return DestinationsRouteBL.GetRemoveDestinationsRoute(id);
        }


    }
}
