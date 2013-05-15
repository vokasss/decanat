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
            if (!CurrentUser.IsAdmin)
            {
                return Error("Действие доступно только администратору");
            }
            var user = DBcontext.Users.Single(u => u.Id == id);
            user.Role = role;
            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = id });
        }

        [HttpGet]
        public ActionResult Ban(int id)
        {
            if (!CurrentUser.IsAdmin)
            {
                return Error("Действие доступно только администратору");
            }
            var user = DBcontext.Users.Single(u => u.Id == id);
            user.Status = (int)AccountStatus.Banned;
            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = id });
        }

        [HttpGet]
        public ActionResult Unban(int id)
        {
            if (!CurrentUser.IsAdmin)
            {
                return Error("Действие доступно только администратору");
            }
            var user = DBcontext.Users.Single(u => u.Id == id);
            user.Status = (int)AccountStatus.Normal;
            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = id });
        }
#endregion

        #region AddEntities
        [HttpGet]
        public ActionResult AddChair()
        {
            if (!CurrentUser.IsAdmin)
            {
                return Error("Действие доступно только администратору");
            }
            return View("~/Views/Entities/add-chair.cshtml", new ChairViewModel() { isAdd = true });
        }

        [HttpPost]
        public ActionResult AddChair(ChairViewModel model)
        {
            var chair = new Chair();
            chair.FacultyId = model.FacultyId;
            chair.Title = model.Title;
            DBcontext.Chairs.Add(chair);
            DBcontext.SaveChanges();
            return RedirectToRoute(HomeRoutes.Home);
        }

        [HttpGet]
        public ActionResult AddFaculty()
        {
            if (!CurrentUser.IsAdmin)
            {
                return Error("Действие доступно только администратору");
            }
            return View("~/Views/Entities/add-faculty.cshtml", new FacultyViewModel() { isAdd = true });
        }

        [HttpPost]
        public ActionResult AddFaculty(FacultyViewModel model)
        {
            var faculty = new Faculty();
            faculty.Title = model.Title;
            DBcontext.Faculties.Add(faculty);
            DBcontext.SaveChanges();
            return RedirectToRoute(HomeRoutes.Home);
        }

        [HttpGet]
        public ActionResult AddGroup()
        {
            if (!CurrentUser.IsAdmin)
            {
                return Error("Действие доступно только администратору");
            }
            return View("~/Views/Entities/add-group.cshtml", new GroupViewModel() { isAdd = true });
        }

        [HttpPost]
        public ActionResult AddGroup(GroupViewModel model)
        {
            var group = new Group();
            group.SpecialityId = model.SpecialityId;
            group.Title = model.Title;
            DBcontext.Groups.Add(group);
            DBcontext.SaveChanges();
            return RedirectToRoute(HomeRoutes.Home);
        }

        [HttpGet]
        public ActionResult AddSpeciality()
        {
            if (!CurrentUser.IsAdmin)
            {
                return Error("Действие доступно только администратору");
            }
            return View("~/Views/Entities/add-speciality.cshtml", new SpecialityViewModel() { isAdd = true });
        }

        [HttpPost]
        public ActionResult AddSpeciality(SpecialityViewModel model)
        {
            var speciality = new Speciality();
            speciality.ChairId = model.ChairId;
            speciality.Title = model.Title;
            DBcontext.Specialities.Add(speciality);
            DBcontext.SaveChanges();
            return RedirectToRoute(HomeRoutes.Home);
        }
#endregion
    }
}
