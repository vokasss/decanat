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
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous || CurrentUser.IsRegisterOnly)
                return Error("Недостаточный уровень доступа");

            return View("~/views/user/student.cshtml", new StudentViewModel() { isAdd = true });
        }

        [HttpPost]
        public ActionResult Add(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/views/user/student.cshtml", model);
            }
            User newUser = new User();
            Student newStudent = new Student();

            var group = DBcontext.Groups.Any(g=>g.Title == model.GroupTitle) ? DBcontext.Groups.Single(g=>g.Title == model.GroupTitle):DBcontext.Groups.Create();
            newStudent.Group = group;
            newStudent.EntryYear = model.EntryYear;
            newStudent.Status = (int)StudyStatus.Active;
            newStudent.Type = (int)model.PaymentStatus;
            newStudent.Characteristic = model.Characteristic;
            newUser.Email = model.Email;
            newUser.BirthDate = model.BirthDate;
            newUser.Gender = model.Gender;
            newUser.FirstName = model.FirstName;
            newUser.LastName = model.LastName;
            newUser.MiddleName = model.MiddleName;
            newUser.LoginName = model.LoginName;
            newUser.Phone = model.Phone;
            newUser.Address = model.Address;
            newUser.Role = (int)AccountRole.Student;
            newUser.Status = (int)AccountStatus.Normal;
            newUser.DateRegistered = DateTime.Now;
            newStudent.User = newUser;
            var father = model.Parents[0];
            father.StudentId = newStudent.Id;
            DBcontext.Parents.Add(father);
            var mother = model.Parents[1];
            mother.StudentId = newStudent.Id;
            DBcontext.Parents.Add(mother);

            var student = DBcontext.Students.Add(newStudent);

            DBcontext.SaveChanges();

            var notes = UsersExtension.CreateSyllabusForStudent(student.Id, student.Group);
            notes.ForEach(n =>
            {
                if (!DBcontext.Notes.Any(nn => nn.StudentId == n.StudentId && nn.SubjectId == n.SubjectId))
                    DBcontext.Notes.Add(n);
            });

            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = newStudent.Id });
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if ((!CurrentUser.IsDecanat && !CurrentUser.IsAdmin) || CurrentUser.IsAnounymous || CurrentUser.IsRegisterOnly)
                return Error("Недостаточный уровень доступа");
            
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
                PaymentStatus = student.Type,
                StudyStatus = student.Status,
                Characteristic = student.Characteristic,
                Parents = student.Parents.ToList(),
                isEdit = true
            };

            return View("~/views/user/student.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.isEdit = true;
                return View("~/views/user/student.cshtml", model);
            }

            Student student = DBcontext.Students.Single(s => s.Id == model.Id);
            var group = DBcontext.Groups.Any(g => g.Title == model.GroupTitle) ? DBcontext.Groups.Single(g => g.Title == model.GroupTitle) : DBcontext.Groups.Create();
            student.Group = group;
            student.User.Email = model.Email;
            student.User.BirthDate = model.BirthDate;
            student.User.Gender = model.Gender;
            student.User.FirstName = model.FirstName;
            student.User.LastName = model.LastName;
            student.User.MiddleName = model.MiddleName;
            student.User.LoginName = model.LoginName;
            student.User.Phone = model.Phone;
            student.User.Address = model.Address;
            student.EntryYear = model.EntryYear;
            student.Type = (int)model.PaymentStatus;
            student.Status = (int)model.StudyStatus;

            var parents = DBcontext.Parents.Where(p=>p.StudentId == student.Id).ToList();
            parents.ForEach(parent => {
                if (parent.User.Gender == (int)Gender.Male) 
                {
                    var newParent = model.Parents[0];
                    parent.User.Job = newParent.User.Job;
                    parent.User.FirstName = newParent.User.FirstName;
                    parent.User.LastName = newParent.User.LastName;
                    parent.User.MiddleName = newParent.User.MiddleName;
                    parent.User.BirthDate = newParent.User.BirthDate;
                    parent.User.Address = newParent.User.Address;
                    parent.User.Phone = newParent.User.Phone;
                    parent.User.Email = newParent.User.Email;
                }
                if (parent.User.Gender == (int)Gender.Female)
                {
                    var newParent = model.Parents[1];
                    parent.User.Job = newParent.User.Job;
                    parent.User.FirstName = newParent.User.FirstName;
                    parent.User.LastName = newParent.User.LastName;
                    parent.User.MiddleName = newParent.User.MiddleName;
                    parent.User.BirthDate = newParent.User.BirthDate;
                    parent.User.Address = newParent.User.Address;
                    parent.User.Phone = newParent.User.Phone;
                    parent.User.Email = newParent.User.Email;
                }
            });

            student.Parents = parents;

            var notes = UsersExtension.CreateSyllabusForStudent(student.Id, student.Group);
            notes.ForEach(n => { 
                if(!DBcontext.Notes.Any(nn=>nn.StudentId == n.StudentId && nn.SubjectId == n.SubjectId))
                DBcontext.Notes.Add(n);
            });
            DBcontext.SaveChanges();

            return RedirectToRoute(UserRoutes.Index, new { id = model.Id });
        }
        #endregion

        [HttpGet]
        public ActionResult StudentStatus(int id, int status)
        {
            if (!CurrentUser.IsAdmin)
            {
                return Error("Действие не доступно");
            }
            var student = DBcontext.Students.Single(u => u.Id == id);
            switch (id)
            {
                case (int)StudyStatus.Active: student.Status = status; student.GraduationYear = null; break;
                case (int)StudyStatus.Expelled: student.Status = status; student.GraduationYear = DateTime.Now.Year; break;
                case (int)StudyStatus.Graduated: student.Status = status; student.GraduationYear = DateTime.Now.Year; break;
            }

            DBcontext.SaveChanges();
            return RedirectToRoute(UserRoutes.Index, new { id = id });
        }

        [HttpGet]
        public ActionResult Notes(int id)
        {
            if(CurrentUser.IsAnounymous || CurrentUser.IsRegisterOnly || (CurrentUser.IsStudent && CurrentUser.Id != id))
                return Error("Недостаточный уровень доступа");
            var student = DBcontext.Students.Single(s => s.Id == id);
            var syl = student.Group.Speciality.Syllabus.Syllabus1;
            var sylla = JsonConvert.DeserializeObject<SyllabusViewModel>(syl);
            var notes = DBcontext.Notes.Where(n => n.StudentId == id);
            List<Tuple<int, List<Note>>> list = new List<Tuple<int, List<Note>>>();
            foreach (var sem in sylla.Syllabus1)
            {
                List<Note> courseNotes = new List<Note>();
                foreach (var subjectId in sem)
                {
                    courseNotes.Add(notes.Single(n => n.SubjectId == subjectId));
                }
                Tuple<int, List<Note>> tuple = new Tuple<int, List<Note>>(sylla.Syllabus1.IndexOf(sem) + 1, courseNotes);
                list.Add(tuple);
            }
            NotesViewModel model = new NotesViewModel();
            model.Student = student;
            model.NotesToSyllabus = list;
            if (Request.IsAjaxRequest())
            {
                return JsonGet(new { view = RenderString("~/views/entities/notes.cshtml", model) });
            }
            return View("~/views/entities/notes.cshtml", model);
        }
    }
}
