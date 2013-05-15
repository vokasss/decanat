using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class NotesViewModel : EditableViewModel
    {
        public Student Student { get; set; }

        public List<Tuple<int, List<Note>>> NotesToSyllabus { get; set; }
    }

    public class SyllabusViewModel : EditableViewModel
    {
        public int SyllabusId { get; set; }

        public Syllabus Syllabus { get; set; }

        public List<List<int>> Syllabus1 { get; set; }

        public string Json { get; set; }

        public List<int> Specialities { get; set; }

        public int Semesters { get; set; }
    }
}