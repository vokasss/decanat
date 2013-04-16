using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iseu;
using Iseu.Models;

namespace Iseu.Core.Entities
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
