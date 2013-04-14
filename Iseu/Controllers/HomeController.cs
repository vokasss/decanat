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

        #region Registration and Login
        [HttpGet]
        public ActionResult Login()
        {
            return View("~/Views/Login/login.cshtml");
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.LoginName, model.RememberMe);
            }   

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
        [HttpGet]
        public ActionResult Search(string pattern)
        {
            var students = !String.IsNullOrEmpty(pattern) ? DBcontext.Students.Search(pattern).ToList() : DBcontext.Students.ToList();
            SearchModel search = new SearchModel();
            search.Pattern = pattern;
            search.Result = students;
            return View("~/Views/Home/search.cshtml", search);
        }
    }
}
