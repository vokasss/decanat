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
        public ActionResult Index(string pattern)
        {
            var students = !String.IsNullOrEmpty(pattern) ? DBcontext.Students.Search(pattern).ToList() : DBcontext.Students.ToList();
            SearchModel search = new SearchModel();
            search.Pattern = pattern;
            search.Result = students;
            return View("~/Views/Home/search.cshtml", search);
        }
        [HttpGet]
        public ActionResult Group(int id)
        {
            SearchModel search = new SearchModel();
            var students = DBcontext.Students.Where(s => s.GroupId == id).ToList();
            search.Result = students;
            return View("~/Views/Home/search.cshtml", search);
        }
    }
}
