using System;
using System.Web;
using System.Web.Mvc;

namespace ABCostmeticClient.Controllers
{
    using Models;
    using System.Web.Security;

    public class AccountController : BaseController
    {
        private readonly UserClient _userClient;

        public AccountController()
        {
            _userClient = new UserClient();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User user)
        {

            var userLogin = _userClient.Login(user);

            if (userLogin != null && userLogin.Id != 0)
            {
                FormsAuthentication.SetAuthCookie(userLogin.StaffId.ToString(), true);

                Session["UserId"] = userLogin.StaffId.ToString();

                var userRole = _userClient.GetUserRole(userLogin.StaffId);
                //var userData = userLogin.StaffId + "," + userRole;

                var authTicket = new FormsAuthenticationTicket(1, userLogin.Username, DateTime.Now, DateTime.Now.AddMinutes(20), false, userRole.Type);
                var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                return RedirectToAction("UserProfile", "Employee");
            }

            ModelState.AddModelError("", "User name or password invalid.");

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}