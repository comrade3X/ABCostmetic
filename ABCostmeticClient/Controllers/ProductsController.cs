using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABCostmeticClient.Models;
namespace ABCostmeticClient.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var userClient = new UserClient();
            var user = new User
            {
                Username = "admin",
                Password = "123456",
            };
            ViewBag.User = userClient.Login(user);

            return View();
        }
    }
}