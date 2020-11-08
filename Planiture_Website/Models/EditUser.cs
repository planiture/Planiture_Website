using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planiture_Website.Models
{
    public class EditUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Email]
        public string Email { get; set; }

        public string Occupation { get; set; }
        public string Address { get; set; }
        public string Residency { get; set; }
        public string Signature { get; set; }
    }
}
