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
using Newtonsoft.Json.Linq;

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

        [HttpPost]
        public IHttpActionResult Search([FromBody] JObject json)
        {
            dynamic data = json;

            string searchFor = data.searchFor;
            DateTime? from = data.from != null ? data.from : null;
            DateTime? to = data.to != null ? data.to : null;

            if (!string.IsNullOrEmpty(searchFor))
            {
                var res = SearchSpecificDate(searchFor);
                return Ok(OrderDto.ConvertToDto(res));
            }
            if (@from != null && to != null)
            {
                var resDateRange = _db.Orders.Where(x => x.OrderDate > @from && x.OrderDate < to);

                return Ok(OrderDto.ConvertToDto(resDateRange));
            }

            var results = OrderDto.ConvertToDto(_db.Orders);
            return Ok(results);
        }

        private IQueryable<Order> SearchSpecificDate(string searchFor)
        {
            var toDay = DateTime.Now;
            if (searchFor.Equals("Daily"))
            {
                var res = _db.Orders.Where(x => x.OrderDate.Month == toDay.Month && x.OrderDate.Day == toDay.Day);

                return res;
            }

            if (!searchFor.Equals("Monthly")) return null;
            {
                var firstDayOfMonth = new DateTime(toDay.Year, toDay.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                var res = _db.Orders.Where(x => x.OrderDate > firstDayOfMonth && x.OrderDate < lastDayOfMonth);

                return res;
            }
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
            var res = "ORD123";

            return res;
        }
    }
}