using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Planiture_Website.Areas.Identity.Pages.Account.RegisterModel;

namespace Planiture_Website.Models
{
    public class Investment_Info
    {
        //Invesment Questions

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvestID { get; set; }

        public string FormType { get; set; }

       // [Required]
        [Display(Name = "Ques1")]
        public string Ques1 { get; set; }


        [Display(Name = "Ques2")]
        public string Ques2 { get; set; }

       // [Required]
        [Display(Name = "Ques3")]
        public string Ques3 { get; set; }

       // [Required]
        [Display(Name = "Ques4")]
        public string Ques4 { get; set; }

       // [Required]
        [Display(Name = "Ques5")]
        public string Ques5 { get; set; }

       // [Required]
        [Display(Name = "Ques6")]
        public string Ques6 { get; set; }

        //Customer Information

        [PersonalData]
        //[Required]
        [Display(Name = "Signature")]
        public string Signature { get; set; }


        //Beneficiary Information

        [PersonalData]
       // [Required]
        [Display(Name = "First Name")]

        public string Bene_FirstName { get; set; }

        [PersonalData]
       // [Required]
        [Display(Name = "Last Name")]

        public string Bene_LastName { get; set; }

        [PersonalData]
       // [Required]
        [Display(Name = "Contact")]
        public string Bene_Contact { get; set; }

        [PersonalData]
       // [Required]
        [Display(Name = "Relationship")]

        public string Bene_Relationship { get; set; }

        [PersonalData]
        //[Required]
        //[Display(Name = "Bene_Email")]
        [EmailAddress]
        public string Bene_Email { get; set; }

        [PersonalData]
        //[Required]
        [Display(Name = "Address")]
        public string BenAddress { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

       // public int CustomerID { get; set; }
       // [ForeignKey("CustomerID")]
       // public InputModel Customer_Info { get; set; }
    }
}
