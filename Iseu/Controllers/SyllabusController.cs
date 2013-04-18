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
    public class SyllabusController : BaseIseuController
    {
        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous)
                return Error("Действие не доступно");

            return View("~/views/syllabus/add.cshtml", new SyllabusModel());
        }

        [HttpPost]
        public ActionResult Add(SyllabusModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("~/views/syllabus/add.cshtml", model);
            }

            DBcontext.SaveChanges();
            return RedirectToRoute(SyllabusRoutes.Index, new { id = model.Id });
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous)
                return Error("Действие не доступно");

            return View("~/views/syllabus/edit.cshtml");
        }

        [HttpPost]
        public ActionResult Edit(SyllabusModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/views/syllabus/edit.cshtml");
            }
            
            DBcontext.SaveChanges();
            return RedirectToRoute(SyllabusRoutes.Index, new { id = model.Id });
        }
        #endregion
    }
}
