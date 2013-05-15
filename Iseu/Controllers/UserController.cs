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
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous || CurrentUser.IsRegisterOnly)
                return Error("Недостаточный уровень доступа");

            return View("~/views/user/user.cshtml", new UserViewModel() { isAdd = true });
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("~/views/user/user.cshtml", model);
            }

            User user = new User();
            
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

            DBcontext.Users.Add(user);
            DBcontext.SaveChanges();

            return RedirectToRoute(UserRoutes.Index, new { id = user.Id });
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous || CurrentUser.IsRegisterOnly)
                return Error("Недостаточный уровень доступа");
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
                Phone = user.Phone,
                isEdit = true
            };
            return View("~/views/user/user.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.isEdit = true;
                return View("~/views/user/user.cshtml", model);
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
            if(CurrentUser.IsAnounymous || CurrentUser.IsRegisterOnly || (CurrentUser.IsStudent && CurrentUser.Id != id))
                return Error("Недостаточный уровень доступа");

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
                    Role = (AccountRole)user.Role,
                    Group = user.Student.Group,
                    Parents = user.Student.Parents.ToList(),
                    PaymentStatus = user.Student.Type,
                    isVisit = true
                };
                return View("~/views/user/student.cshtml", studentModel);
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
                    Role = (AccountRole)user.Role,
                    AcademicDegree = user.Professor.ADegree1,
                    AcademicTitle = user.Professor.ATitle1,
                    Chair = user.Professor.Chair,
                    Subjects = user.Professor.Subjects.ToList(),
                    isVisit = true
                };
                return View("~/views/user/professor.cshtml", professorModel);
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
                Role = (AccountRole)user.Role,
                isVisit = true
            };
            return View("~/views/user/user.cshtml", userModel);
        }
        #endregion
    }
}
