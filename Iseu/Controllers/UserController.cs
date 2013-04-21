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
        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous)
                return Error("Действие не доступно");

            return View("~/views/user/add.cshtml", new UserViewModel());
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                 return View("~/Views/User/add.cshtml", model);
            }

            User user = DBcontext.Users.Add(new User());
            
            user.Address = model.Address;
            user.BirthDate = model.BirthDate;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.Gender = model.Gender;
            user.LastName = model.LastName;
            user.MiddleName = model.MiddleName;
            user.Phone = model.Phone;
            user.Role = (int)AccountRole.Decanat;
            user.Status = (int)AccountStatus.Normal;
            user.DateRegistered = DateTime.Now;

            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = user.Id });
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous)
                return Error("Действие не доступно");
            User user = null;
            if (!DBcontext.Users.Any(u => u.Id == id))
            {
                return PageNotFound();
            }
            else
            {
                user = DBcontext.Users.Single(u => u.Id == id);
            }

            UserViewModel model = new UserViewModel()
            {
                Id = user.Id,
                Address = user.Address,
                BirthDate = user.BirthDate,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Phone = user.Phone
            };
            return View("~/views/user/edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/views/user/edit.cshtml");
            }

            User user = DBcontext.Users.Single(s => s.Id == model.Id);
            user.Address = model.Address;
            user.BirthDate = model.BirthDate;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.Gender = model.Gender;
            user.LastName = model.LastName;
            user.MiddleName = model.MiddleName;
            user.Phone = model.Phone;
            Password pass = Password.Create(model.Password);
            user.Password = pass.Hash;
            user.Salt = pass.Salt;

            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = model.Id });
        }
        #endregion

        #region Index
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
                StudentViewModel studentModel = new StudentViewModel()
                {
                    Id = user.Id,
                    Characteristic = user.Student.Characteristic,
                    StudyStatus = user.Student.Status,
                    EntryYear = user.Student.EntryYear,
                    GraduationYear = user.Student.GraduationYear,
                    Address = user.Address,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Gender = user.Gender,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                    LoginName = user.LoginName,
                    Phone = user.Phone,
                    Role = user.Role,
                    Group = user.Student.Group,
                    Parents = user.Student.Parents.ToList(),
                    PaymentStatus = user.Student.Type,
                    isGuest = CurrentUser.Id != user.Id,
                    GuestIsAdmin = CurrentUser.IsAdmin,
                    GuestIsDecanat = CurrentUser.IsDecanat
                };
                return View("~/views/student/student.cshtml", studentModel);
            }
            if (user.IsProfessor)
            {
                ProfessorViewModel professorModel = new ProfessorViewModel()
                {
                    Id = user.Id,
                    Address = user.Address,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Gender = user.Gender,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                    Phone = user.Phone,
                    Role = user.Role,
                    AcademicDegree = user.Professor.ADegree1,
                    AcademicTitle = user.Professor.ATitle1,
                    Chair = user.Professor.Chair,
                    Subjects = user.Professor.Subjects.ToList(),
                    isGuest = CurrentUser.Id != user.Id,
                    GuestIsAdmin = CurrentUser.IsAdmin,
                    GuestIsDecanat = CurrentUser.IsDecanat
                };
                return View("~/views/professor/professor.cshtml", professorModel);
            }
            UserViewModel userModel = new UserViewModel()
            {
                Id = user.Id,
                Address = user.Address,
                BirthDate = user.BirthDate,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Phone = user.Phone,
                Role = user.Role,
                isGuest = CurrentUser.Id != user.Id,
                GuestIsAdmin = CurrentUser.IsAdmin,
                GuestIsDecanat = CurrentUser.IsDecanat
            };
            return View("~/views/user/user.cshtml", userModel);
        }
        #endregion
    }
}
