using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class StudentViewModel {
        public int Id { get; set; }
        public Nullable<int> EntryYear { get; set; }
        public Nullable<int> GraduationYear { get; set; }
        public Nullable<int> Type { get; set; }
        public string Group { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> CityId { get; set; }
        public string Address { get; set; }
        public List<Parent> Parent { get; set; }
    }
}