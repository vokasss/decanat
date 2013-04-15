//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Iseu
{
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;
    using Iseu.Models;
    
    public partial class User
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
        
        public virtual Parent Parent { get; set; }
        public virtual Student Student { get; set; }

        public bool IsAnounymous
        {
            get
            {
                return Id < 1;
            }
        }

        public bool IsStudent
        {
            get
            {
                return Student != null;
            }
        }

        public bool IsBanned
        {
            get
            {
                return Status == (int)AccountStatus.Banned;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return Role == (int)AccountRole.Admin;
            }
        }

        public bool IsDecanat
        {
            get
            {
                return Role == (int)AccountRole.Decanat;
            }
        }
    }
}
