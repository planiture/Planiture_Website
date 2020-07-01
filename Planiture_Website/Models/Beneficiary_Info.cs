using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planiture_Website.Models
{
    public class Beneficiary_Info
    {
        [PersonalData]
        [Display(Name = "Ben_FirstName")]
        public string Ben_FirstName { get; set; }

        [PersonalData]
        [Display(Name = "Ben_LastName")]
        public string Ben_LastName { get; set; }

        [PersonalData]
        [Display(Name = "Ben_Contact")]
        public string Ben_Contact { get; set; }

        [PersonalData]
        [Display(Name = "Ben_Relationship")]
        public string Ben_Relationship { get; set; }

        [PersonalData]
        [Display(Name = "Ben_Email")]
        public string Ben_Email { get; set; }

        [PersonalData]
        [Display(Name = "Ben_Address")]
        public string Ben_Address { get; set; }

        [PersonalData]
        public string Ben_CustomerID { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
