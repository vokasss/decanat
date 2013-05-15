using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public interface IGuestableModel {

        bool isGuest { get; }

        bool GuestIsAdmin { get; }

        bool GuestIsDecanat { get; }
        
    }
}