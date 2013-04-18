using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class StudentViewModel : UserViewModel
    {
        [Display(Name = "Группа")]
        public string GroupTitle { get; set; }

        public Group Group { get; set; }

        public Nullable<int> StudyStatus { get; set; }

        [Display(Name = "Год поступления")]
        public Nullable<int> EntryYear { get; set; }

        public Nullable<int> GraduationYear { get; set; }

        public Nullable<int> Type { get; set; }

        public List<Parent> Parents { get; set; }

        [Display(Name = "Характеристика")]
        public string Characteristic { get; set; }

        [Display(Name = "Номер зачетки")]
        public string LoginName { get; set; }
       
    }
}