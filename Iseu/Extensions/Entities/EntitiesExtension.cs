using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Iseu.Models;
using Iseu;

namespace Iseu.Models
{
    public static class EntitiesExtension
    {
        public static Entities DBcontext = new Entities();
       /* public static int ExistOrNewCity(this string city)
        {
            
        }*/
        public static IEnumerable<Student> Search(this IEnumerable<Student> students, string pattern)
        {
            return students.Where(s => (!String.IsNullOrEmpty(s.User.FirstName) && s.User.FirstName.Contains(pattern))
                || (!String.IsNullOrEmpty(s.User.LastName) && s.User.LastName.Contains(pattern))
                || (!String.IsNullOrEmpty(s.User.MiddleName) && s.User.MiddleName.Contains(pattern))
                || (!String.IsNullOrEmpty(s.Group.Title) && s.Group.Title.Contains(pattern))
                || (!String.IsNullOrEmpty(s.User.Address) && s.User.Address.Contains(pattern)));
        }
    }
}