using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{ 
    public enum SearchEntity{
        User,
        Student,
        Professor,
        Subject,
        Group
    }
    public class SearchModel {
        public SearchEntity Entity { get; set; }
        public string Pattern { get; set; }
        public object Result { get;set; }
    }
}