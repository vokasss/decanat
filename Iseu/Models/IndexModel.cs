﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class IndexModel {

        public User User { get; set; }
        public SearchModel Search { get; set; }
    
    }
}