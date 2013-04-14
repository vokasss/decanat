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

        public Student Student { get; set; }
        public int Id { get; set; }
        public Nullable<int> EntryYear { get; set; }
        public Nullable<int> GraduationYear { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> Type { get; set; }
        public string Group { get; set; }
    }
}