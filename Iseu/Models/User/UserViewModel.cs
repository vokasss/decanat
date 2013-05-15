using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class UserViewModel : EditableViewModel
    {
        [Required]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> BirthDate { get; set; }

        [Required]
        [Display(Name = "Пол")]
        public Nullable<int> Gender { get; set; }
        
        [Required]
        [Display(Name = "Имя")]
        [StringLength(100, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        [StringLength(100, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        [StringLength(255, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 10)]
        public string Address { get; set; }

        public string Password { get; set; }

        [Display(Name = "Установить уровень доступа")]
        public AccountRole Role { get; set; }

        [Display(Name="Установить статус аккаунта")]
        public AccountStatus AccountStatus { get; set; }

        [Display(Name = "ФИО")]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1} {2}", LastName, FirstName, MiddleName);
            }
        }

        
    }
}