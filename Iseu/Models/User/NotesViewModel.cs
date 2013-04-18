using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class NotesViewModel : GuestableModel
    {
        public Student Student { get; set; }

        public List<Tuple<int, List<Note>>> NotesToSyllabus { get; set; }
    }

    public class SyllabusModel
    {
        public int Id { get; set; }

        public List<List<int>> Syllabus { get; set; }

        public List<Group> Groups { get; set; }
    }
}