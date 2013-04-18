using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iseu.Models
{
    public enum AccountStatus 
    {
        Normal,
        Banned
    }

    public enum AccountRole 
    { 
        Student,
        Professor,
        Decanat,
        Admin
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum PaymentStatus
    {
        Free,
        Paid
    }

    public enum StudyStatus
    {
        Active,
        Graduated,
        Expelled
    }
}