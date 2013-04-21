using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class ProfessorViewModel : UserViewModel
    {
        public Chair Chair { get; set; }
        [Display(Name = "Кафедра")]
        public int ChairId { get; set; }

        public ADegree AcademicDegree { get; set; }
        [Display(Name = "Ученая степень")]
        public int AcademicDegreeId { get; set; }

        public ATitle AcademicTitle { get; set; }
        [Display(Name = "Ученое звание")]
        public int AcademicTitleId { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}