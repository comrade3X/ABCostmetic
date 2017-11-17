using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ABCostmeticServer.DTO;
using ABCostmeticServer.Models;

namespace ABCostmeticServer.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly WCF_ABCostmeticEntities _db = new WCF_ABCostmeticEntities();

        // GET: api/Employees
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var res = EmployeeDto.ConvertToDto(_db.Employees);

            return res;
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            var res = EmployeeDto.ConvertToDto(employee);

            return Ok(res);
        }

        /// <summary>
        /// Get employee data and all orders
        /// </summary>
        /// <param name="emplId"></param>
        /// <returns></returns>
        //public IHttpActionResult GetEmployeeAndOrders(int emplId)
        //{
        //    if (emplId == 0)
        //    {
        //        return NotFound();
        //    }

        //    var employee = _db.Employees.Find(emplId);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok();
        //}

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            _db.Entry(employee).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Employees.Add(employee);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(employee);
            _db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return _db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}