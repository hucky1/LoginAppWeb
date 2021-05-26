﻿    using LoginAppWeb.Models;
using LoginAppWeb.Services.Business;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginAppWeb.Controllers
{
    public class LoginController : Controller
    {
        private static Logger logger = LogManager.GetLogger("myAppLogerrule");
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }
        public ActionResult Login(UserModel userModel)
        {
            logger.Info("Entering the login controller. Login method");
            try
            {
                SecurityService securityService = new SecurityService();
                bool success = securityService.Authenticate(userModel);
                if (success)
                {
                    logger.Info("Exit login controller. Login success.");
                    return View("LoginSuccess", userModel);
                }
                else
                {
                    logger.Info("Exit login controller. Login failure!");
                    return View("LoginFailure");
                }
            }
            catch(Exception ex)
            {
                logger.Error($"Exception {ex.Message}");
                return Content($"Exception in login {ex.Message}");
            }
            //return $"Results. Username = {userModel.Username}. Password = {userModel.Password}";
           
        }
    }
}