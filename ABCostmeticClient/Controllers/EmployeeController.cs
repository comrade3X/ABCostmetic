using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ABCostmeticClient.Models;

namespace ABCostmeticClient.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly EmployeeClient _employeeClient;

        public EmployeeController()
        {

            _employeeClient = new EmployeeClient();
        }

        [Authorize(Roles = "National Manager")]
        // GET: Employee
        public ActionResult Index()
        {
            var listEmployee = _employeeClient.FindAll();

            return View(listEmployee);
        }

        public ActionResult Detail(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Error500", "Error");
            }

            var emp = _employeeClient.GetEmployee(id);

            if (emp == null)
            {
                return RedirectToAction("Error500", "Error");
            }

            return View(emp);
        }

        public ActionResult UserProfile()
        {
            var userId = Session["UserId"];

            return userId == null ? RedirectToAction("Error500", "Error") : RedirectToAction("Detail", new { id = userId });
        }

        public ActionResult _EmployeeOrders(int emplId)
        {
            var listOrder = _employeeClient.GetOrdersByEmployee(emplId);

            return PartialView("_employeeOrders", listOrder);
        }
    }
}