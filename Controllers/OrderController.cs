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
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        //פונקציה השולפת רשימת הזמנות
        [Route("GatAllOrder")]
        [HttpGet]
        public List<OrderEntities> GetAllOrder()
        {
            return OrderBL.GetAllOrder();
        }

        //פונקציה השולפת הזמנה על פי קוד
        [Route("GetIdOrder/{id}")]
        [HttpGet]
        public OrderEntities GetIdOrder(int id)
        {
            return OrderBL.GetIdOrder(id);
        }

        //פונקציה השולפת את כל ההזמנות על פי קוד
        [Route("GetAllIdOrder/{id}")]
        [HttpGet]
        public List<OrderEntities> GetAllIdOrder(int id)
        {
            var listOrder= OrderBL.GetAllIdOrder(id);
            return listOrder;
        }

        //פונקציה המוסיפה הזמנה
        [Route("GetAddOrder")]
        [HttpPut]
        public List<OrderEntities> GetAddOrder([FromBody] OrderEntities C)
        {
            return OrderBL.GetAddOrder(C);
        }

        //פונקציה המעדכנת הזמנה שקיימת
        [Route("GetUpdatOrder")]
        [HttpPost]
        public List<OrderEntities> GetUpdatOrder([FromBody] OrderEntities C)
        {
            return OrderBL.GetUpdatOrder(C);
        }

        //פונקציה שמוחקת הזמנה שקיימת
        [Route("GetRemoveOrder/{id}")]
        [HttpDelete]
        public List<OrderEntities> GetRemoveOrder(int id)
        {
            return OrderBL.GetRemoveOrder(id);
        }

        [Route("GetOrderTrack/{id}")]
        [HttpGet]
        public int GetOrderTrack(int id)
        {
            return OrderBL.GetOrderTrack(id);
        }
        
    }
}
