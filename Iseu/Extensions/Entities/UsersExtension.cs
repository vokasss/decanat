using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            ret.Role = (int)AccountRole.Student;
            ret.Status = (int)AccountStatus.Normal;
            return ret;
        }

        public static User Fictive
        {
            get { return new User() { Id = 0 }; }
        }


        public static List<SelectListItem> GetGenders()
        {
            var items = new List<SelectListItem>();
            var listItem = new SelectListItem
            {
                Value = ((int)Models.Gender.Male).ToString(),
                Text = "М"
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)Models.Gender.Female).ToString(),
                Text = "Ж"
            };
            items.Add(listItem);
            return items;
        }

        public static List<SelectListItem> GetAcademicTitles()
        {
            var items = new List<SelectListItem>();
            var listItem = new SelectListItem
            {
                Value = ((int)Models.Gender.Male).ToString(),
                Text = "М"
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)Models.Gender.Female).ToString(),
                Text = "Ж"
            };
            items.Add(listItem);
            return items;
        }

        public static List<SelectListItem> GetAcademicDegrees()
        {
            var items = new List<SelectListItem>();
            var listItem = new SelectListItem
            {
                Value = ((int)Models.Gender.Male).ToString(),
                Text = "М"
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)Models.Gender.Female).ToString(),
                Text = "Ж"
            };
            items.Add(listItem);
            return items;
        }
    }
}