using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iseu.Models;

namespace Iseu.Controllers
{
    public class BaseIseuController : Controller
    {
        public Entities DBcontext;

        public User CurrentUser
        {
            get
            {
                return !String.IsNullOrEmpty(HttpContext.User.Identity.Name) ? DBcontext.Users.Single(u => u.LoginName == HttpContext.User.Identity.Name): UsersExtension.Fictive;
            }
        }
        
        public BaseIseuController()
        {
            DBcontext = new Entities();
        }
    }
}
