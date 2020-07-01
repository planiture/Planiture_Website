using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planiture_Website.Models
{
    public class InvestmentQuestion
    {
        [PersonalData]
        [Display(Name = "FormType")]
        public string FormType { get; set; }

        [PersonalData]
        [Display(Name = "Ques1")]
        public string Ques1 { get; set; }

        public string Ques2 { get; set; }

        [PersonalData]
        [Display(Name = "Ques3")]
        public string Ques3 { get; set; }

        [PersonalData]
        [Display(Name = "Ques4")]
        public string Ques4 { get; set; }

        [PersonalData]
        [Display(Name = "Ques5")]
        public string Ques5 { get; set; }

        [PersonalData]
        [Display(Name = "Ques6")]
        public string Ques6 { get; set; }

        public string Cus_CustomerID { get; set; }
    }
}
