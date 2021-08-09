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
    [RoutePrefix("api/CarsTypes")]
    public class CarsTypesController : ApiController
    {
        //פונקציה השולפת רשימת סוגי רכבים
        [Route("GatAllCarsTypes")]
        [HttpGet]
        public List<CarsTypesEntities> GetAllCarsTypes()
        {
            return CarsTypesBL.GetAllCarsTypes();
        }

        //פונקציה השולפת סוג רכב על פי קוד
        [Route("GetIdCarsTypes/{id}")]
        [HttpGet]
        public CarsTypesEntities GetIdCarsTypes(int id)
        {
            return CarsTypesBL.GetIdCarsTypes(id);
        }

        //פונקציה המוסיפה סוג רכב
        [Route("GetAddCarsTypes")]
        [HttpPut]
        public List<CarsTypesEntities> GetAddCarsTypes([FromBody] CarsTypesEntities C)
        {
            return CarsTypesBL.GetAddCarsTypes(C);
        }

        //פונקציה המעדכנת סוג רכב קיימים
        [Route("GetUpdatCarsTypes")]
        [HttpPost]
        public List<CarsTypesEntities> GetUpdatCarsTypes([FromBody] CarsTypesEntities C)
        {
            return CarsTypesBL.GetUpdatCarsTypes(C);
        }

        //פונקציה שמוחקת סוג רכב קיים
        [Route("GetRemoveCarsTypes/{id}")]
        [HttpDelete]
        public List<CarsTypesEntities> GetRemoveCarsTypes(int id)
        {
            return CarsTypesBL.GetRemoveCarsTypes(id);
        }
    }
}
