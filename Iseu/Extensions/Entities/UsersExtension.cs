using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Iseu.Models;

namespace Iseu.Models
{
    public static class UsersExtension
    {
        public static User New(RegisterModel model)
        {
            Password pass = Password.Create(model.Password);
            User ret = new User();
            ret.FirstName = ret.LoginName = model.LoginName;
            ret.DateLastVisited = ret.DateRegistered = DateTime.Now;
            ret.Password = pass.Hash;
            ret.Salt = pass.Salt;
            ret.Email = model.Email;
            ret.Role = (int)AccountRole.Normal;
            ret.Status = (int)AccountStatus.Normal;
            return ret;
        }

        public static User Fictive
        {
            get { return new User() { Id = 0 }; }
        }
    }
}