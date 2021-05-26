using LoginAppWeb.Models;
using LoginAppWeb.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginAppWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }
        public ActionResult Login(UserModel userModel)
        {
            //return $"Results. Username = {userModel.Username}. Password = {userModel.Password}";
            SecurityService securityService = new SecurityService();
            bool success = securityService.Authenticate(userModel);
            if (success)
            {
                return View("LoginSuccess",userModel);
            }
            else
            {
                return View("LoginFailure");
            }
        }
    }
}