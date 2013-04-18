using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iseu.Models;
using Iseu;

namespace Iseu.Controllers
{
    public class BaseIseuController : Controller
    {
        public BaseIseuController()
        {
            DBcontext = new Entities();
        }

        #region Fields
        public Entities DBcontext;

        public User CurrentUser
        {
            get
            {
                return Core.CurrentUser;
            }
        }
        #endregion

        #region Errors
        public ActionResult Error(string e)
        {
            return View("~/Views/Errors/Error.cshtml", (object)e);
        }

        public ActionResult PageNotFound()
        {
            return View("~/Views/Errors/404.cshtml");
        }
        #endregion
    }
}
