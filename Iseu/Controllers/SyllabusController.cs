using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iseu;
using Iseu.Routing;
using Iseu.Models;
using Newtonsoft.Json;
using System.Threading;

namespace Iseu.Controllers
{
    public class SyllabusController : BaseIseuController
    {
        #region Add
        [HttpGet]
        public ActionResult GetCourses()
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous || CurrentUser.IsRegisterOnly)
                return Error("Недостаточный уровень доступа");
            if (Request.IsAjaxRequest())
            {
                return JsonGet(new { view = RenderString("~/views/entities/get-courses.cshtml", null) });
            }
            return View("~/views/entities/get-courses.cshtml");
        }

        [HttpPost]
        public ActionResult GetCourses(int count)
        {
            if (!ModelState.IsValid)
            {
                return View("~/views/entities/get-courses.cshtml", count);
            }
            return View("~/views/entities/add-syllabus.cshtml", new SyllabusViewModel() { isAdd = true, Semesters = count*2 });
        }

        [HttpGet]
        public ActionResult GetSubject(string stitle, int pid)
        {
            var subjects = DBcontext.Subjects;
            if (subjects.Any(s => s.ProfessorId == pid && s.Title == stitle))
                return JsonGet(new { id = subjects.Single(s => s.ProfessorId == pid && s.Title == stitle).Id });
            else {
                Subject newSubj = new Subject();
                newSubj.ProfessorId = pid;
                newSubj.Title = stitle;
                Subject subj = DBcontext.Subjects.Add(newSubj);
                return JsonGet(new { id = subj.Id });
            }
        }

        [HttpPost]
        public ActionResult Add(string json)
        {
            //string json = "{\"Syllabus\":"+model.Json+"}";
            var model = JsonConvert.DeserializeObject<SyllabusViewModel>(json);
            model.Syllabus1.ForEach(s => {
                s = s.Distinct().ToList();
            });
            Thread.Sleep(1000);

            Syllabus newSyllabus = new Syllabus();
            var specialities = DBcontext.Specialities.Where(s => model.Specialities.Contains(s.Id)).ToList();
            newSyllabus.Specialities = specialities;
            newSyllabus.Syllabus1 = json.Substring(0, json.IndexOf("]]")+2) + "}";
            DBcontext.Syllabuses.Add(newSyllabus);

            DBcontext.SaveChanges();
           
            return RedirectToRoute(HomeRoutes.Home);
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous || CurrentUser.IsRegisterOnly)
                return Error("Недостаточный уровень доступа");

            return View("~/views/entities/syllabus.cshtml");
        }

        [HttpPost]
        public ActionResult Edit(SyllabusViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/views/entities/syllabus.cshtml");
            }
            
            DBcontext.SaveChanges();
            return RedirectToRoute(SyllabusRoutes.Index, new { id = model.Id });
        }
        #endregion
    }
}
