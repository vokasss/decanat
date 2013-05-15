using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class SubjectViewModel : EditableViewModel
    {
        public int SubjectId { get; set; }
        
        [Required]
        [Display(Name="Дисциплина")]
        public string Title { get; set; }

        [Display(Name = "Преподаватель")]
        public Professor Professor { get; set; }

        public int ProfessorId { get; set; }
    }
}