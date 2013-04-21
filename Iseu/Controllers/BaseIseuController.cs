using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iseu.Models;
using Iseu;
using System.IO;

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

        public string RenderString(string view, object model)
        {
            if (string.IsNullOrEmpty(view))
                view = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, view);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
        public JsonResult JsonGet(object obj) {
            var js = Json(obj);
            js.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return js;
        }
    }
}
