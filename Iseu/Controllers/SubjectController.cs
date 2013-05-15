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
    public class SubjectController : BaseIseuController
    {
        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous || CurrentUser.IsRegisterOnly)
                return Error("Недостаточный уровень доступа");

            return View("~/views/entities/subject.cshtml", new SubjectViewModel());
        }

        [HttpPost]
        public ActionResult Add(SubjectViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("~/views/entities/subject.cshtml", model);
            }
            DBcontext.SaveChanges();
            return RedirectToRoute(SubjectRoutes.Subject, new { id = model.SubjectId });
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous || CurrentUser.IsRegisterOnly)
                return Error("Недостаточный уровень доступа");

            return View("~/views/entities/subject.cshtml");
        }

        [HttpPost]
        public ActionResult Edit(SubjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/views/entities/subject.cshtml");
            }
            
            DBcontext.SaveChanges();
            return RedirectToRoute(SubjectRoutes.Subject, new { id = model.SubjectId });
        }
        #endregion

        [HttpGet]
        public ActionResult Subject(int id)
        {
            var subject = DBcontext.Subjects.Single(s => s.Id == id);
            return View("~/views/entities/subject.cshtml", subject);
        }
    }
}
