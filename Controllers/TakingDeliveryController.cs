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
    [RoutePrefix("api/TakingDelivery")]
    public class TakingDeliveryController : ApiController
    {
        //פונקציה השולפת רשימת פרטי לקיחת משלוח
        [Route("GatAllTakingDelivery")]
        [HttpGet]
        public List<TakingDeliveryEntities> GetAllTaking()
        {
            return TakingDeliveryBL.GetAllTakingDelivery();
        }

        //פונקציה השולפת פרטי לקיחת משלוח על פי קוד
        [Route("GetIdTakingDeliver/{id}")]
        [HttpGet]
        public TakingDeliveryEntities GetIdTakingDelivery(int id)
        {
            return TakingDeliveryBL.GetIdTakingDelivery(id);
        }

        //פונקציה המוסיפה פרטי לקיחת משלוח
        [Route("GetAddTakingDeliver")]
        [HttpPut]
        public List<TakingDeliveryEntities> GetAddTakingyDeliver([FromBody] TakingDeliveryEntities C)
        {
            return TakingDeliveryBL.GetAddTakingDelivery(C);
        }

        //פונקציה המעדכנת פרטי לקיחת משלוח שקיים
        [Route("GetUpdatTakingDelivery")]
        [HttpPost]
        public List<TakingDeliveryEntities> GetUpdatTakingDelivery([FromBody] TakingDeliveryEntities C)
        {
            return TakingDeliveryBL.GetUpdatTakingDelivery(C);
        }

        //פונקציה שמוחקת פרטי לקיחת משלוח שקיים
        [Route("GetRemoveTakingDelivery/{id}")]
        [HttpDelete]
        public List<TakingDeliveryEntities> GetRemoveTakingDelivery(int id)
        {
            return TakingDeliveryBL.GetRemoveTakingDelivery(id);
        }
    }
}
