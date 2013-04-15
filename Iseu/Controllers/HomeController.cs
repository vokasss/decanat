using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iseu;
using Iseu.Routing;
using Iseu.Models;
using System.Web.Security;

namespace Iseu.Controllers
{
    public class HomeController : BaseIseuController
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml", new IndexModel() { User = CurrentUser });
        }

        public ActionResult Header()
        {
            return PartialView("~/Views/partial/header.cshtml", new HeaderModel() { User = CurrentUser });
        }

        #region Registration and Login
        [HttpGet]
        public ActionResult Login()
        {
            return View("~/Views/Login/login.cshtml");
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            User user = null;

            if (DBcontext.Users.Any(u => u.LoginName == model.LoginName && u.Status != (int)AccountStatus.Banned))
                user = DBcontext.Users.Single(u => u.LoginName == model.LoginName);
            else
            {
                ViewBag.Failed = 1;
                ViewBag.Message = "Пользователя с таким логином не существует";
                return RedirectToRoute(HomeRoutes.Home);
            }
            if(user.Password != Password.CalculateHash(user.Salt, model.Password))
            {
                ViewBag.Failed = 1;
                ViewBag.Message = "Неверный пароль";
                return RedirectToRoute(HomeRoutes.Home);
            }
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.LoginName, model.RememberMe);
            }
            ViewBag.Failed = 0;
            return RedirectToRoute(HomeRoutes.Home);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("~/Views/Login/register.cshtml");
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if(model.Password != model.ConfirmPassword || !ModelState.IsValid)
            {
                ViewBag.Failed = 1;
                return View("~/Views/Login/register.cshtml", model);
            }
            var user = (UsersExtension.New(model));
            DBcontext.Users.Add(user);
            DBcontext.SaveChanges();
            FormsAuthentication.SetAuthCookie(model.LoginName, false); 
            return RedirectToRoute(HomeRoutes.Home);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToRoute(HomeRoutes.Home);
        }

        #endregion
    }
}
