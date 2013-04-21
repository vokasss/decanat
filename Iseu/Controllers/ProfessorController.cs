using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iseu;
using Iseu.Routing;
using Iseu.Models;
using Newtonsoft.Json;

namespace Iseu.Controllers
{
    public class ProfessorController : BaseIseuController
    {
        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            if (CurrentUser.IsStudent || CurrentUser.IsAnounymous)
                return Error("Действие не доступно");

            return View("~/views/professor/add.cshtml", new ProfessorViewModel());
        }

        [HttpPost]
        public ActionResult Add(ProfessorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/views/professor/add.cshtml", model);
            }
            User newUser = DBcontext.Users.Add(new User());
            Professor professor = DBcontext.Professors.Add(new Professor());

            professor.ChairId = model.ChairId;
            professor.ADegree = model.AcademicDegreeId;
            professor.ATitle = model.AcademicTitleId;
            newUser.CityId = 1;
            newUser.Email = model.Email;
            newUser.BirthDate = model.BirthDate;
            newUser.Gender = model.Gender;
            newUser.FirstName = model.FirstName;
            newUser.LastName = model.LastName;
            newUser.MiddleName = model.MiddleName;
            newUser.Phone = model.Phone;
            newUser.Address = model.Address;
            newUser.Role = (int)AccountRole.Professor;
            newUser.Status = (int)AccountStatus.Normal;
            newUser.DateRegistered = DateTime.Now;
            professor.User = newUser;

            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = professor.Id });
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (CurrentUser.IsStudent || CurrentUser.IsAnounymous)
                return Error("Действие не доступно");

            Professor professor = null;
            if (!DBcontext.Professors.Any(u => u.Id == id))
            {
                return PageNotFound();
            }
            else
            {
                professor = DBcontext.Professors.Single(p => p.Id == id);
            }
            ProfessorViewModel model = new ProfessorViewModel()
            {
                Id = professor.Id,
                FirstName = professor.User.FirstName,
                LastName = professor.User.LastName,
                MiddleName = professor.User.MiddleName,
                BirthDate = professor.User.BirthDate,
                Gender = professor.User.Gender,
                Address = professor.User.Address,
                Email = professor.User.Email,
                Phone = professor.User.Phone,
                AcademicDegreeId = professor.ADegree.Value,
                AcademicTitleId = professor.ATitle.Value,
                ChairId = professor.Chair.Id
            };

            return View("~/views/professor/edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(ProfessorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/views/professor/edit.cshtml", model);
            }

            Professor professor = DBcontext.Professors.Single(p=>p.Id == model.Id);
            professor.User.CityId = 1;
            professor.User.Email = model.Email;
            professor.User.BirthDate = model.BirthDate;
            professor.User.Gender = model.Gender;
            professor.User.FirstName = model.FirstName;
            professor.User.LastName = model.LastName;
            professor.User.MiddleName = model.MiddleName;
            professor.User.Phone = model.Phone;
            professor.User.Address = model.Address;
            professor.ChairId = model.ChairId;
            professor.ADegree = model.AcademicDegreeId;
            professor.ATitle = model.AcademicTitleId;

            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = model.Id });
        }
        #endregion
    }
}
