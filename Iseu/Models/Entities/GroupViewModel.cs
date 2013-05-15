using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class GroupViewModel : EditableViewModel
    {
        [Display(Name = "Название")]
        public string Title { get; set; }

        public Group Group { get; set; }

        [Display(Name = "Специальность")]
        public int SpecialityId { get; set; }
    }
}