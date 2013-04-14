using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iseu.Models
{
    interface IUser
    {
        int Id { get; }
        Nullable<System.DateTime> BirthDate { get; }
        Nullable<int> Gender { get; }
        string FirstName { get; }
        string LastName { get; }
        string MiddleName { get; }
        string Email { get; }
        string Phone { get; }
        Nullable<int> CityId { get; }
        string Address { get; }
        int Role { get; }
        int Status { get; }
        string LoginName { get; }
        string Password { get; }
        string Salt { get; }
        Nullable<System.DateTime> DateRegistered { get; }
        Nullable<System.DateTime> DateLastVisited { get; }
    }
}
