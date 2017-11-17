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
using ABCostmeticServer.Models;
using ABCostmeticServer.DTO;

namespace ABCostmeticServer.Controllers
{
    public class UsersController : ApiController
    {
        private WCF_ABCostmeticEntities db = new WCF_ABCostmeticEntities();

        [Route("api/users/login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody]UserDto param)
        {
            if (string.IsNullOrEmpty(param.Username) || string.IsNullOrEmpty(param.Password))
            {
                return NotFound();
            }

            var user = db.Users.FirstOrDefault(x => x.Username.Equals(param.Username) && x.Password.Equals(param.Password));
            var res = UserDto.ConvertToDto(user);

            return Ok(res);
        }

        [Route("api/users/getuserrole")]
        public IHttpActionResult GetUserRole(int emplId)
        {
            if (emplId == 0)
            {
                return NotFound();
            }

            var empl = db.Employees.Find(emplId);

            if (empl == null)
            {
                return NotFound();
            }

            var emplDto = EmployeeDto.ConvertToDto(empl);

            return Ok(emplDto.StaffType);
        }

        // GET: api/Users
        public List<UserDto> GetUsers()
        {
            var res = db.Users.ToList();
            var res2 = UserDto.ConvertToDto(res);
            return res2.ToList();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}