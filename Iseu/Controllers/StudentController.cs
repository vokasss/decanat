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
    public class StudentController : BaseIseuController
    {
        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous)
                return Error("Действие не доступно");

            return View("~/views/student/add.cshtml", new StudentViewModel());
        }

        [HttpPost]
        public ActionResult Add(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/views/student/add.cshtml", model);
            }

            Student newStudent = DBcontext.Students.Add(new Student());
            var group = DBcontext.Groups.Single(g=>g.Title == model.GroupTitle);
            newStudent.Group = group;
            newStudent.User.CityId = 1;
            newStudent.User.Email = model.Email;
            newStudent.User.BirthDate = model.BirthDate;
            newStudent.User.Gender = model.Gender;
            newStudent.User.FirstName = model.FirstName;
            newStudent.User.LastName = model.LastName;
            newStudent.User.MiddleName = model.MiddleName;
            newStudent.User.LoginName = model.LoginName;
            newStudent.User.Phone = model.Phone;
            newStudent.User.Address = model.Address;
            newStudent.EntryYear = model.EntryYear;
            newStudent.User.Role = (int)AccountRole.Student;
            newStudent.User.Status = (int)AccountStatus.Normal;
            newStudent.Status = (int)StudyStatus.Active;
            newStudent.Type = model.Type;
            newStudent.User.DateRegistered = DateTime.Now;
            foreach (var p in model.Parents)
            {
                p.StudentId = newStudent.Id;
                DBcontext.Parents.Add(p);
            }

            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = newStudent.Id });
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous)
                return Error("Действие не доступно");
            
            Student student = null;
            if (!DBcontext.Students.Any(u => u.Id == id))
            {
                return PageNotFound();
            }
            else
            {
                student = DBcontext.Students.Single(u => u.Id == id);
            }
            StudentViewModel model = new StudentViewModel()
            {
                Id = student.Id,
                FirstName = student.User.FirstName,
                LastName = student.User.LastName,
                MiddleName = student.User.MiddleName,
                LoginName = student.User.LoginName,
                BirthDate = student.User.BirthDate,
                Gender = student.User.Gender,
                Address = student.User.Address,
                Email = student.User.Email,
                Phone = student.User.Phone,
                GroupTitle = student.User.Student.Group.Title,
                EntryYear = student.EntryYear,
                Type = student.User.Student.Type,
                Characteristic = student.Characteristic,
                Parents = student.Parents.ToList()
            };

            return View("~/views/student/edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/views/student/edit.cshtml", model);
            }

            Student newStudent = DBcontext.Students.Single(s => s.Id == model.Id);
            var group = DBcontext.Groups.Single(g => g.Title == model.GroupTitle);
            newStudent.Group = group;
            newStudent.User.CityId = 1;
            newStudent.User.Email = model.Email;
            newStudent.User.BirthDate = model.BirthDate;
            newStudent.User.Gender = model.Gender;
            newStudent.User.FirstName = model.FirstName;
            newStudent.User.LastName = model.LastName;
            newStudent.User.MiddleName = model.MiddleName;
            newStudent.User.LoginName = model.LoginName;
            newStudent.User.Phone = model.Phone;
            newStudent.User.Address = model.Address;
            newStudent.EntryYear = model.EntryYear;
            newStudent.Type = model.Type;
            newStudent.Parents = model.Parents;

            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = model.Id });
        }
        #endregion

        #region Activate Expelle Graduate
        [HttpGet]
        public ActionResult Activate(int id)
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous)
            {
                return Error("Действие не доступно");
            }
            var student = DBcontext.Students.Single(u => u.Id == id);
            student.Status = (int)StudyStatus.Active;
            student.GraduationYear = null;
            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = id });
        }

        [HttpGet]
        public ActionResult Graduate(int id)
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous)
            {
                return Error("Действие не доступно");
            }
            var student = DBcontext.Students.Single(u => u.Id == id);
            student.Status = (int)StudyStatus.Graduated;
            student.GraduationYear = DateTime.Now.Year;
            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = id });
        }

        [HttpGet]
        public ActionResult Expelle(int id)
        {
            if (!CurrentUser.IsAdmin)
            {
                return Error("Действие не доступно");
            }
            var student = DBcontext.Students.Single(u => u.Id == id);
            student.Status = (int)StudyStatus.Expelled;
            student.GraduationYear = DateTime.Now.Year;
            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = id });
        }
        #endregion

        [HttpGet]
        public ActionResult Notes(int id)
        {
            var student = DBcontext.Students.Single(s => s.Id == id);
            var syl = DBcontext.Syllabuses.Single(s => s.Groups.Select(g => g.Id).Contains(student.GroupId.Value)).Syllabus1;
            var sylla = JsonConvert.DeserializeObject<SyllabusModel>(syl);
            var notes = DBcontext.Notes.Where(n => n.StudentId == id);
            List<Tuple<int, List<Note>>> list = new List<Tuple<int, List<Note>>>();
            foreach (var course in sylla.Syllabus)
            {
                List<Note> courseNotes = new List<Note>();
                foreach (var subjectId in course)
                {
                    courseNotes.Add(notes.Single(n => n.SubjectId == subjectId));
                }
                Tuple<int, List<Note>> tuple = new Tuple<int, List<Note>>(sylla.Syllabus.IndexOf(course) + 1, courseNotes);
                list.Add(tuple);
            }
            NotesViewModel model = new NotesViewModel();
            model.Student = student;
            model.NotesToSyllabus = list;
            return View("~/views/student/notes.cshtml", model);
        }
    }
}
