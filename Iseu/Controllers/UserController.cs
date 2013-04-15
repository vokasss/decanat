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
    public class UserController : BaseIseuController
    {
        [HttpGet]
        public ActionResult Index(int id)
        {
            User user = null;
            if (!DBcontext.Users.Any(u => u.Id == id))
            {
                return PageNotFound();
            }
            else
            {
               user = DBcontext.Users.Single(u => u.Id == id);
            }
            if (user.IsStudent)
            {
                StudentViewModel model = new StudentViewModel()
                {
                    Id = user.Id,
                    GraduationYear = user.Student.GraduationYear,
                    EntryYear = user.Student.EntryYear,
                    Address = user.Address,
                    BirthDate = user.BirthDate,
                    CityId = 1,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Gender = user.Gender,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                    Phone = user.Phone,
                    Role = user.Role,
                    Group = user.Student.Group.Title,
                    Type = user.Student.Type,
                    isGuest = CurrentUser.Id != user.Id,
                    GuestIsAdmin = CurrentUser.IsAdmin,
                    GuestIsDecanat = CurrentUser.IsDecanat
                };
                return View("~/Views/User/student.cshtml", model);
            }
            return View("~/Views/User/user.cshtml", user);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("~/Views/User/add.cshtml", new StudentViewModel());
        }

        [HttpPost]
        public ActionResult Add(StudentViewModel model)
        {
            if(!ModelState.IsValid)
            {
                 return View("~/Views/User/add.cshtml");
            }

            Student newStudent = DBcontext.Students.Add(new Student());

            newStudent.GraduationYear = model.GraduationYear;
            newStudent.EntryYear = model.EntryYear;
            newStudent.User.Address = model.Address;
            newStudent.User.BirthDate = model.BirthDate;
            newStudent.User.CityId = 1;
            newStudent.User.Email = model.Email;
            newStudent.User.FirstName = model.FirstName;
            newStudent.User.Gender = model.Gender;
            newStudent.User.LastName = model.LastName;
            newStudent.User.MiddleName = model.MiddleName;
            newStudent.User.Phone = model.Phone;
            newStudent.User.Role = model.Role;
            newStudent.Status = (int)StudyStatus.Active;
            newStudent.User.Status = (int)AccountStatus.Normal;
            newStudent.Type = model.Type;
            //#TODO Parents
            /*
            foreach (var p in model.Parent)
            {
                p.StudentId = newStudent.Id;
                DBcontext.Parents.Add(p);
            }*/
            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = newStudent.Id });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = null;
            if (!DBcontext.Users.Any(u => u.Id == id))
            {
                return PageNotFound();
            }
            else
            {
                user = DBcontext.Users.Single(u => u.Id == id);
            }
            if (user.IsStudent)
            {
                StudentViewModel model = new StudentViewModel()
                {
                    Id = user.Id,
                    GraduationYear = user.Student.GraduationYear,
                    EntryYear = user.Student.EntryYear,
                    Address = user.Address,
                    BirthDate = user.BirthDate,
                    CityId = 1,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Gender = user.Gender,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                    Phone = user.Phone,
                    Role = user.Role,
                    Group = user.Student.Group.Title,
                    Type = user.Student.Type,
                    isGuest = CurrentUser.Id != user.Id,
                    GuestIsAdmin = CurrentUser.IsAdmin,
                    GuestIsDecanat = CurrentUser.IsDecanat
                };
                return View("~/Views/User/edit-student.cshtml", model);
            }
            return View("~/Views/User/edit-user.cshtml", user);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/User/add.cshtml");
            }

            Student student = DBcontext.Students.Single(s => s.Id == model.Id);
            student.User.Address = model.Address;
            student.User.BirthDate = model.BirthDate;
            student.User.CityId = 1;
            student.User.Email = model.Email;
            student.User.FirstName = model.FirstName;
            student.User.Gender = model.Gender;
            student.User.LastName = model.LastName;
            student.User.MiddleName = model.MiddleName;
            student.User.Phone = model.Phone;
            student.User.Status = (int)AccountStatus.Normal;
            student.GraduationYear = model.GraduationYear;
            student.EntryYear = model.EntryYear;
            student.Status = (int)StudyStatus.Active;
            student.Type = model.Type;
            //#TODO Parents
            /*foreach (var p in model.Parent)
            {
                Parent parent = DBcontext.Parents.Single(par => par.Id == p.Id);
                parent.Job = p.Job;
            }*/
            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = model.Id });
        }

    }
}
