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
            return View("~/views/home/index.cshtml");
        }

        public ActionResult Header()
        {
            return PartialView("~/views/header/header.cshtml", new HeaderModel() { User = CurrentUser });
        }

        #region Registration and Login
        [HttpGet]
        public ActionResult Login()
        {
            return View("~/views/login/login.cshtml");
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            User user = null;

            if (DBcontext.Users.Any(u => u.LoginName == model.LoginName && u.Status != (int)AccountStatus.Banned))
            {
                user = DBcontext.Users.Single(u => u.LoginName == model.LoginName); 
            }
            else
            {
                ViewBag.Failed = 1;
                ViewBag.Message = "Пользователя с таким логином не существует";
                return RedirectToRoute(HomeRoutes.Home);
            }

            if (String.IsNullOrEmpty(user.Password))
            {
                var pass = Password.Create(model.Password);
                user.Password = pass.Hash;
                user.Salt = pass.Salt;
                DBcontext.SaveChanges();
            }
            else if (user.Password != Password.CalculateHash(user.Salt, model.Password))
            {
                ViewBag.Failed = 1;
                ViewBag.Message = "Неверный пароль";
                return RedirectToRoute(HomeRoutes.Home);
            }
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.LoginName, true);
            }
            ViewBag.Failed = 0;
            return RedirectToRoute(HomeRoutes.Home);
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (Request.IsAjaxRequest())
            {
                return JsonGet(new { view = RenderString("~/Views/Login/register.cshtml", new RegisterModel()) });
            }
            return View("~/Views/Login/register.cshtml", new RegisterModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if(model.Password != model.ConfirmPassword || !ModelState.IsValid || DBcontext.Users.Any(u=>u.LoginName == model.LoginName))
            {
                if (Request.IsAjaxRequest())
                {
                    return JsonGet(new { view = RenderString("~/Views/Login/register.cshtml", model), success = 0 });
                }
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
            CurrentUser.DateLastVisited = DateTime.Now;
            DBcontext.SaveChanges();

            FormsAuthentication.SignOut();

            return RedirectToRoute(HomeRoutes.Home);
        }

        #endregion
    }
}
