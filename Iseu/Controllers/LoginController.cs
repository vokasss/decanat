using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iseu.Models;

namespace Iseu.Controllers
{
    public class LoginController : BaseIseuController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View("~/Views/Login/login.cshtml");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("~/Views/Login/register.cshtml");
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            return Redirect("");
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            return Redirect("");
        }
    }
}
