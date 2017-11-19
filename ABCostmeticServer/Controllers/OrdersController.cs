using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ABCostmeticServer.Models;

namespace ABCostmeticServer.Controllers
{
    using DTO;

    public class OrdersController : ApiController
    {
        private readonly WCF_ABCostmeticEntities _db = new WCF_ABCostmeticEntities();

        // GET: api/Orders
        public IEnumerable<OrderDto> GetOrders()
        {
            var res = OrderDto.ConvertToDto(_db.Orders);
            return res;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            var res = OrderDto.ConvertToDto(order);

            return Ok(res);
        }

        public IHttpActionResult GetOrderByEmployeeId(int emplId)
        {
            var order = _db.Orders.Where(x => x.Seller == emplId);

            var res = OrderDto.ConvertToDto(order);

            return Ok(res);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            _db.Entry(order).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder([FromBody]OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            var order = new Order
            {
                Customer = orderDto.Customer,
                Seller = orderDto.Seller,
                OrderDate = DateTime.Now,
                OrderCode = GenerateOrderCode(),
                //OrderDetails = new List<OrderDetail>
                //{
                //    new OrderDetail
                //    {
                //       ProductId = 3829,
                //        Quantity = 1
                //    },
                //    new OrderDetail()
                //    {
                //        ProductId = 3830,
                //        Quantity = 2
                //    },
                //}
            };
            
            _db.Orders.Add(order);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        public IHttpActionResult PostOrderDetail([FromBody]OrderDetailDto orderDetailsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetails = new OrderDetail()
            {
               OrderId = orderDetailsDto.OrderId,
               ProductId = orderDetailsDto.ProductId,
               Quantity = orderDetailsDto.Quantity
            };

            _db.OrderDetails.Add(orderDetails);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderDetails.Id }, orderDetails);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = _db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            _db.Orders.Remove(order);
            _db.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return _db.Orders.Count(e => e.Id == id) > 0;
        }

        private string GenerateOrderCode()
        {
            var res ="ORD123";

            return res;
        }
    }
}