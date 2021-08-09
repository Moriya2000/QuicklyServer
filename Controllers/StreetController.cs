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
    [RoutePrefix("api/Street")]
    public class StreetController : ApiController
    {
        //פונקציה השולפת רשימת רחובות
        [Route("GatAllStreet")]
        [HttpGet]
        public List<StreetEntities> GetAllStreet()
        {
            return StreetBL.GetAllStreet();
        }

        //פונקציה השולפת רחוב על פי קוד
        [Route("GetIdStreet/{id}")]
        [HttpGet]
        public StreetEntities GetIdStreet(int id)
        {
            return StreetBL.GetIdStreet(id);
        }

        //פונקציה המוסיפה רחוב
        [Route("GetAddStreet")]
        [HttpPut]
        public List<StreetEntities> GetAddStreet([FromBody] StreetEntities C)
        {
            return StreetBL.GetAddStreet(C);
        }

        //פונקציה המעדכנת רחוב שקיים
        [Route("GetUpdatStreet")]
        [HttpPost]
        public List<StreetEntities> GetUpdatStreet([FromBody] StreetEntities C)
        {
            return StreetBL.GetUpdatStreet(C);
        }

        //פונקציה שמוחקת רחוב שקיים
        [Route("GetRemoveStreet/{id}")]
        [HttpDelete]
        public List<StreetEntities> GetRemoveStreet(int id)
        {
            return StreetBL.GetRemoveStreet(id);
        }
    }
}
