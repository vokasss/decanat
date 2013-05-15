using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iseu.Models;

namespace Iseu.Controllers
{
    public class SearchController : BaseIseuController
    {
        [HttpGet]
        public ActionResult Index(string pattern, int entity = (int)SearchEntity.Student)
        {
            if (CurrentUser.IsAnounymous || CurrentUser.IsRegisterOnly)
                return Error("Недостаточный уровень доступа");

            if (CurrentUser.IsStudent)
            {
                List<Student> list = new List<Student>();
                list.Add(CurrentUser.Student);
                SearchModel search1 = new SearchModel();
                search1.Result = list;
                return View("~/Views/Home/search.cshtml", search1);
            }
            SearchModel search = new SearchModel();
            search.Pattern = pattern;
            switch (entity)
            {
               case (int)SearchEntity.Professor:
                    var professors = !String.IsNullOrEmpty(pattern) ? DBcontext.Professors.Search(pattern).ToList() : DBcontext.Professors.ToList();
                    search.Result = professors;
                    search.Entity = SearchEntity.Professor;
                    break;
                case (int)SearchEntity.User:
                    var validUsers = DBcontext.Users.Where(u => u.Role != null && u.Role <= CurrentUser.Role);
                    var users = !String.IsNullOrEmpty(pattern) ? validUsers.Search(pattern).ToList() : validUsers.ToList();
                    search.Result = users;
                    search.Entity = SearchEntity.User;
                    break;
                case (int)SearchEntity.Group:
                    var groups = !String.IsNullOrEmpty(pattern) ? DBcontext.Groups.Where(g=>g.Title.Contains(pattern.ToLower())).ToList() : DBcontext.Groups.ToList();
                    search.Result = groups;
                    search.Entity = SearchEntity.Group;
                    break;
                case (int)SearchEntity.Subject:
                    var subjects = !String.IsNullOrEmpty(pattern) ? DBcontext.Subjects.Where(g => g.Title.Contains(pattern.ToLower())).ToList() : DBcontext.Subjects.ToList();
                    search.Result = subjects;
                    search.Entity = SearchEntity.Subject;
                    break;
                default:
                    var students = !String.IsNullOrEmpty(pattern) ? DBcontext.Students.Search(pattern).ToList() : DBcontext.Students.ToList();
                    search.Result = students;
                    search.Entity = SearchEntity.Student;
                    break;
            }
            return View("~/Views/Home/search.cshtml", search);
        }
    }
}
