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
        

        [Route("GetAllOrderByIdCompany/{id}")]
        [HttpGet]
        public IHttpActionResult GetAllOrderByIdCompany(int id)
        {
            var listRoute = DeliveryRoutesBL.GetListDeliveryRoutesByIDCompany(id);
            List<AllOrder> aa = new List<AllOrder>();
            List<List<AllOrder>> routeToCompanyWithOrders = new List<List<AllOrder>>();
            foreach (var item in listRoute)
            {
                var allOrderInRoute = DestinationsRouteBL.GetAllDestinationsRoute(item.DeliveryRoutesID);
                aa = new List<AllOrder>();
                foreach (var item1 in allOrderInRoute)
                {
                    aa.Add(TakingDeliveryBL.GetAllOrder(item1.OrderID));
                }
                routeToCompanyWithOrders.Add(aa);
            }
            return Ok(routeToCompanyWithOrders);
        }

        [Route("GetAllOrder")]
        [HttpGet]
        public IHttpActionResult GetAllOrder()
        { List<AllOrder> aa = new List<AllOrder>();
            aa.Add(TakingDeliveryBL.GetAllOrder(38));
            aa.Add(TakingDeliveryBL.GetAllOrder(39));
            aa.Add(TakingDeliveryBL.GetAllOrder(40));
            aa.Add(TakingDeliveryBL.GetAllOrder(41));
            aa.Add(TakingDeliveryBL.GetAllOrder(42));
            aa.Add(TakingDeliveryBL.GetAllOrder(43));
          return Ok(aa);
        }
        //פונקציה השולפת רשימת פרטי לקיחת משלוח
        [Route("GatAllTakingDelivery")]
        [HttpGet]
        public List<TakingDeliveryEntities> GetAllTaking()
        {
            return TakingDeliveryBL.GetAllTakingDelivery();
        }

        //פונקציה השולפת פרטי לקיחת משלוח על פי קוד
        [Route("GetAllOrder/{id}")]
        [HttpGet]
        public IHttpActionResult GetAllOrder(int id)
        {
            return Ok(TakingDeliveryBL.GetAllOrder(id));
        }

        //פונקציה השולפת פרטי לקיחת משלוח על פי קוד
        [Route("GetIdTakingDeliver/{id}")]
        [HttpGet]
        public TakingDeliveryEntities GetIdTakingDelivery(int id)
        {
            return TakingDeliveryBL.GetIdTakingDelivery(id);
        }

        //פונקציה המוסיפה פרטי משלוח
        [Route("GetAddAllOrder")]
        [HttpPut]
        public IHttpActionResult GetAddAllOrder([FromBody] AllOrder C)
        {
           var id= TakingDeliveryBL.GetAddAllOrder(C);
            var order = TakingDeliveryBL.GetAllOrder(id);
           return Ok(order);
        }

        //פונקציה שמוסיפה  פרטי לקיחת משלוח
        [Route("GetAddTakingDelivery")]
        [HttpPut]
        public List<TakingDeliveryEntities> GetAddTakingDelivery([FromBody] TakingDeliveryEntities C)
        {
            return TakingDeliveryBL.GetAddTakingDelivery(C);
        }

        //פונקציה המעדכנת פרטי משלוח
        [Route("GetUpdatAllOrder")]
        [HttpPost]
        public void GetUpdatAllOrder(AllOrder C)
        {
            TakingDeliveryBL.GetUpdatAllOrder(C);
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

    public class routeToCompanyWithOrders
    {
        public List<AllOrder> allOrders { get; set; }
    }
}
