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
            var productClient = new ProductClient();

            var list = productClient.FindAll();

            return View();
        }
    }
}