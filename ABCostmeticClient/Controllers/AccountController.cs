using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCostmeticClient.Controllers
{
    using Models;
    using System.Web.Security;

    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {            

            UserClient userClient = new UserClient();
            var userLogin = userClient.Login(user);

            if (userLogin != null && userLogin.Id != 0)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "User name or password invalid.");

            return View();
        }
    }
}