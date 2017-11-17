using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABCostmeticClient.Models;

namespace ABCostmeticClient.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductClient _productClient;

        public ProductsController()
        {
            _productClient = new ProductClient();
        }

        // GET: Products
        public ActionResult Index()
        {
            ViewBag.List = _productClient.FindAll();

            return View();
        }
    }
}