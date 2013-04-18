using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Iseu.Models;

namespace Iseu
{
    public static class Core
    {
        public static User CurrentUser
        { 
            get
            {
                return !String.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) ? new Entities().Users.Single(u => u.LoginName == HttpContext.Current.User.Identity.Name) : UsersExtension.Fictive;
            }
        }
    }
}
