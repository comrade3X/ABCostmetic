using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCostmeticClient.Controllers
{
    using Models;

    [Authorize]
    public class OrderController : BaseController
    {
        private readonly ProductClient _productClient;
        private readonly EmployeeClient _employeeClient;
        private readonly OrderClient _orderClient;
        private readonly CustomerClient _customerClient;

        public OrderController()
        {
            _productClient = new ProductClient();
            _employeeClient = new EmployeeClient();
            _orderClient = new OrderClient();
            _customerClient = new CustomerClient();
        }

        [Authorize(Roles = "National Manager")]
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _ListOrder()
        {
            var list = _orderClient.FindAll();

            return PartialView("~/Views/Employee/_employeeOrders.cshtml", list);
        }

        public ActionResult Create()
        {
            var vm = new OrderViewModel();
            var listProduct = _productClient.FindAll();
            vm.ProductSelectList = new SelectList(listProduct, "Id", "Name");
            vm.Employee = _employeeClient.GetEmployee(Convert.ToInt32(Session["UserId"]));
            return View(vm);
        }

        [HttpPost]
        public JsonResult Create(List<OrderDetails> orderDetails, Customer customer)
        {
            try
            {
                customer.Gender = "Male";
                customer.IdentityCard = "887799445511";
                customer.Address = "HCM";
                customer.DateOfBirth = DateTime.Now;
                var customerCreated = _customerClient.Create(customer);
                var empl = _employeeClient.GetEmployee(Convert.ToInt32(Session["UserId"]));

                var order = new Order
                {
                    Customer = customerCreated.Id,
                    Seller = empl.Id,
                    OrderDate = DateTime.Now,
                    OrderDetails = orderDetails,
                };

                var orderCreated = _orderClient.CreateOrder(order);

                foreach (var item in orderDetails)
                {
                    var orderDetail = new OrderDetails
                    {
                        OrderId = orderCreated.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                    };

                    var detailsCreated = _orderClient.CreateOrderDetail(orderDetail);
                }

                return Json(new { url = Url.Action("UserProfile", "Employee") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { url = Url.Action("Index", "Home") }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}