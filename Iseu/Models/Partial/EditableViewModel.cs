using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public class EditableViewModel: IGuestableModel
    {
        public int Id { get; set; }

        public bool isEdit { get; set; }

        public bool isAdd { get; set; }

        public bool isVisit { get; set; }

        public EditableViewModel() {

            isEdit = false;

            isAdd = false;

            isVisit = false;

        }

        public bool isGuest
        {
            get
            {
                return Core.CurrentUser.Id != Id;
            }
        }

        public bool GuestIsDecanat
        {
            get
            {
                return Core.CurrentUser.IsDecanat;
            }
        }

        public bool GuestIsAdmin
        {
            get
            {
                return Core.CurrentUser.IsAdmin;
            }
        }
    }
}