using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class ChairViewModel : EditableViewModel
    {
        [Display(Name="Название")]
        public string Title { get; set; }

        public Chair Chair { get; set; }

        [Display(Name="Факультет")]
        public int FacultyId { get; set; }
    }
}