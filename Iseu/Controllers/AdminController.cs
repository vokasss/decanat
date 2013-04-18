using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iseu;
using Iseu.Routing;
using Iseu.Models;

namespace Iseu.Controllers
{
    public class AdminController : BaseIseuController
    {
        #region Actions
        [HttpGet]
        public ActionResult SetRole(int id, int role)
        {
            if (!CurrentUser.IsAdmin || CurrentUser.IsAnounymous)
            {
                return Error("Действие доступно только администратору");
            }
            var user = DBcontext.Users.Single(u => u.Id == id);
            user.Role = role;
            DBcontext.SaveChanges();
            return RedirectToAction("User", "Index", new { id = id });
        }

        [HttpGet]
        public ActionResult Ban(int id)
        {
            if (!CurrentUser.IsAdmin || CurrentUser.IsAnounymous)
            {
                return Error("Действие доступно только администратору");
            }
            var user = DBcontext.Users.Single(u => u.Id == id);
            user.Status = (int)AccountStatus.Banned;
            DBcontext.SaveChanges();
            return RedirectToAction("User", "Index", new { id = id });
        }

        [HttpGet]
        public ActionResult Unban(int id)
        {
            if (!CurrentUser.IsAdmin || CurrentUser.IsAnounymous)
            {
                return Error("Действие доступно только администратору");
            }
            var user = DBcontext.Users.Single(u => u.Id == id);
            user.Status = (int)AccountStatus.Normal;
            DBcontext.SaveChanges();
            return RedirectToAction("User", "Index", new { id = id });
        }
#endregion
    }
}
