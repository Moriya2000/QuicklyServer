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
    [RoutePrefix("api/City")]
    public class CityController : ApiController
    {
        //פונקציה השולפת רשימת ערים
        [Route("GatAllCity")]
        [HttpGet]
        public List<CityEntities> GetAllCity()
        {
            return CityBL.GetAllCity();
        }

        //פונקציה השולפת ערים על פי קוד
        [Route("GetIdCity/{id}")]
        [HttpGet]
        public CityEntities GetIdCity(int id)
        {
            return CityBL.GetIdCity(id);
        }

        //פונקציה המוסיפה ערים
        [Route("GetAddCity")]
        [HttpPut]
        public List<CityEntities> GetAddCity([FromBody] CityEntities C)
        {
            return CityBL.GetAddCity(C);
        }

        //פונקציה המעדכנת עיר שקיימת
        [Route("GetUpdatCity")]
        [HttpPost]
        public List<CityEntities> GetUpdatCity([FromBody] CityEntities C)
        {
            return CityBL.GetUpdatCity(C);
        }

        //פונקציה שמוחקת עיר שקיימת
        [Route("GetRemoveCity/{id}")]
        [HttpDelete]
        public List<CityEntities> GetRemoveCity(int id)
        {
            return CityBL.GetRemoveCity(id);
        }
    }
}
