using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iseu.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> CityId { get; set; }
        public string Address { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Nullable<System.DateTime> DateRegistered { get; set; }
        public Nullable<System.DateTime> DateLastVisited { get; set; }

        public virtual Parent Parents { get; set; }
        public virtual Student Students { get; set; }


        public User New(RegisterModel1 model)
        {
            var pass = Iseu.Models.Password.Create(model.Password);
            User ret = new User();
            ret.LoginName = model.UserName;
            ret.Password = pass.Hash;
            ret.Salt = pass.Salt;
            ret.DateLastVisited = DateTime.Now;
            ret.DateRegistered = DateTime.Now;
            ret.Email = model.Email;
            ret.FirstName = model.UserName;
            ret.Role = (int)AccountRole.Normal;
            ret.Status = (int)AccountStatus.Normal;
            return ret;
        }
    }
}