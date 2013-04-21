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
            User ret = new User();
            ret.FirstName = model.FirstName;
            ret.LastName = model.LastName;
            ret.LoginName = model.LoginName;
            ret.BirthDate = model.BirthDate;
            ret.DateLastVisited = ret.DateRegistered = DateTime.Now;
            Password pass = Password.Create(model.Password);
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

        public static List<SelectListItem> GetPayments()
        {
            var items = new List<SelectListItem>();
            var listItem = new SelectListItem
            {
                Value = ((int)Models.PaymentStatus.Free).ToString(),
                Text = "Бесплатно"
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)Models.PaymentStatus.Paid).ToString(),
                Text = "Платно"
            };
            items.Add(listItem);
            return items;
        }

        public static List<SelectListItem> GetStudyStatus()
        {
            var items = new List<SelectListItem>();
            var listItem = new SelectListItem
            {
                Value = ((int)Models.StudyStatus.Active).ToString(),
                Text = "Учится"
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)Models.StudyStatus.Expelled).ToString(),
                Text = "Отчислен"
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)Models.StudyStatus.Graduated).ToString(),
                Text = "Окончил"
            };
            items.Add(listItem);
            return items;
        }

        public static List<SelectListItem> GetAcademicTitles()
        {
            var items = new List<SelectListItem>();
            var DBcontext = new Entities();
            foreach (var item in DBcontext.ATitles)
            {
                items.Add(new SelectListItem
            {
                Value = (item.Id).ToString(),
                Text = item.Title
            });
            }
            return items;
        }

        public static List<SelectListItem> GetAcademicDegrees()
        {
            var items = new List<SelectListItem>();
            var DBcontext = new Entities();
            foreach (var item in DBcontext.ADegrees)
            {
                items.Add(new SelectListItem
                {
                    Value = (item.Id).ToString(),
                    Text = item.Title
                });
            }
            return items;
        }

        public static List<SelectListItem> GetChairs()
        {
            var items = new List<SelectListItem>();
            var DBcontext = new Entities();
            foreach (var item in DBcontext.Chairs)
            {
                items.Add(new SelectListItem
                {
                    Value = (item.Id).ToString(),
                    Text = item.Title
                });
            }
            return items;
        }
    }
}