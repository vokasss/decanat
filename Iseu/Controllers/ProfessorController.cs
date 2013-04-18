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

            Professor professor = DBcontext.Professors.Add(new Professor());
            professor.User.CityId = 1;
            professor.User.Email = model.Email;
            professor.User.BirthDate = model.BirthDate;
            professor.User.Gender = model.Gender;
            professor.User.FirstName = model.FirstName;
            professor.User.LastName = model.LastName;
            professor.User.MiddleName = model.MiddleName;
            professor.User.Phone = model.Phone;
            professor.User.Address = model.Address;
            professor.ChairId = model.Chair.Id;
            professor.ADegree = model.AcademicDegree.Id;
            professor.ATitle = model.AcademicTitle.Id;
            professor.User.Role = (int)AccountRole.Professor;
            professor.User.Status = (int)AccountStatus.Normal;
            professor.User.DateRegistered = DateTime.Now;

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
                AcademicDegree = professor.ADegree1,
                AcademicTitle = professor.ATitle1,
                Chair = professor.Chair
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
            professor.ChairId = model.Chair.Id;
            professor.ADegree = model.AcademicDegree.Id;
            professor.ATitle = model.AcademicTitle.Id;

            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = model.Id });
        }
        #endregion
    }
}
