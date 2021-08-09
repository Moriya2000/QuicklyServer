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
    [RoutePrefix("api/GivingDelivery")]
    public class GivingDeliveryController : ApiController
    {
        //פונקציה השולפת רשימת פרטי נתינת משלוח
        [Route("GatAllGivingDelivery")]
        [HttpGet]
        public List<GivingDeliveryEntities> GetAllGivingDelivery()
        {
            return GivingDeliveryBL.GetAllGivingDelivery();
        }

        //פונקציה השולפת פרטי נתינת משלוח על פי קוד
        [Route("GetIdGivingDelivery/{id}")]
        [HttpGet]
        public GivingDeliveryEntities GetIdGivingDelivery(int id)
        {
            return GivingDeliveryBL.GetIdGivingDelivery(id);
        }

        //פונקציה המוסיפה פרטי נתינת משלוח
        [Route("GetAddGivingDelivery")]
        [HttpPut]
        public List<GivingDeliveryEntities> GetAddGivingDelivery([FromBody] GivingDeliveryEntities C)
        {
            return GivingDeliveryBL.GetAddGivingDelivery(C);
        }

        //פונקציה המעדכנת פרטי נתינת משלוח שקיים
        [Route("GetUpdatGivingDelivery")]
        [HttpPost]
        public List<GivingDeliveryEntities> GetUpdatGivingDelivery([FromBody] GivingDeliveryEntities C)
        {
            return GivingDeliveryBL.GetUpdatGivingDelivery(C);
        }

        //פונקציה שמוחקת פרטי נתינת משלוח שקיים
        [Route("GetRemoveGivingDelivery/{id}")]
        [HttpDelete]
        public List<GivingDeliveryEntities> GetRemoveGivingDelivery(int id)
        {
            return GivingDeliveryBL.GetRemoveGivingDelivery(id);
        }
    }
}
