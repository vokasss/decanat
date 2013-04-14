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
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentViewModel model)
        {
            return View();
        }
    }
}
