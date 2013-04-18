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
    public partial class User
    {
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

        public bool IsProfessor
        {
            get
            {
                return Professor != null;
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

        public string FullName
        {
            get
            {
                return String.Format("{0} {1} {2}",LastName, FirstName, MiddleName);
            }
        }
        public string ShortFullName
        {
            get
            {
                return String.Format("{0} {1}. {2}.", LastName, FirstName[0], MiddleName[0]);
            }
        }
    }
}
