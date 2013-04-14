using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iseu;
using Iseu.Routing;
using Iseu.Models;
using System.Web.Security;

namespace Iseu.Controllers
{
    public class StudentController : BaseIseuController
    {
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View("~/Views/Student/add.cshtml");
        }

        [HttpPost]
        public ActionResult AddStudent(StudentViewModel model)
        {
            if(!ModelState.IsValid)
            {
                 return View("~/Views/Student/add.cshtml");
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
            newStudent.User.Role = (int)AccountRole.Normal;
            newStudent.Status = (int)StudyStatus.Active;
            newStudent.User.Status = (int)AccountStatus.Normal;
            newStudent.Type = model.Type;
            foreach (var p in model.Parent)
            {
                p.StudentId = newStudent.Id;
                DBcontext.Parents.Add(p);
            }
            DBcontext.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult EditStudent(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Student/add.cshtml");
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
            foreach (var p in model.Parent)
            {
                Parent parent = DBcontext.Parents.Single(par => par.Id == p.Id);
                parent.Job = p.Job;
            }
            DBcontext.SaveChanges();
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public ActionResult Student(StudentViewModel model)
        {

            return View("~/Views/Student/student.cshtml");
        }

    }
}
