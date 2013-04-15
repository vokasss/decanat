using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class GuestableModel {

        public bool isGuest { get; set; }
        public bool GuestIsAdmin { get; set; }
        public bool GuestIsDecanat { get; set; }
    }
}