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
    [RoutePrefix("api/BusinessDays")]
    public class BusinessDaysController : ApiController
    {
        //פונקציה השולפת רשימת ימי עסקים
        [Route("GatAllDays")]
        [HttpGet]
        public List<BusinessDaysEntities> GetAllDays()
        {
            return BusinessDaysBL.GetAllDays();
        }

        //פונקציה השולפת ימי עסקים על פי קוד
        [Route("GetIdBusinessDays/{id}")]
        [HttpGet]
        public BusinessDaysEntities GetIdBusinessDays(int id)
        {
            return BusinessDaysBL.GetIdBusinessDays(id);
        }

        //פונקציה המוסיפה ימי עסקים
        [Route("GetAddDay")]
        [HttpPut]
        public List<BusinessDaysEntities> GetAddDay([FromBody] BusinessDaysEntities C)
        {
            return BusinessDaysBL.GetAddDay(C);
        }

        //פונקציה המעדכנת ימי עסקים קיים
        [Route("GetUpdatDay")]
        [HttpPost]
        public List<BusinessDaysEntities> GetUpdatDay([FromBody] BusinessDaysEntities C)
        {
            return BusinessDaysBL.GetUpdatDay(C);
        }

        //פונקציה שמוחקת ימי עסקים קיימים
        [Route("GetRemoveDay/{id}")]
        [HttpDelete]
        public List<BusinessDaysEntities> GetRemoveDay(int id)
        {
            return BusinessDaysBL.GetRemoveDay(id);
        }
    }
}
