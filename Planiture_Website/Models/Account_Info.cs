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
    public class Account_Info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountNumber { get; set; }

        [PersonalData]
        [Display(Name = "AccountName")]
        public string AccountName { get; set; }

        [PersonalData]
        [Display(Name = "AccountType")]
        public string AccountType { get; set; }

        [PersonalData]
        [Display(Name = "AvailableBalance")]
        public float AvailableBalance { get; set; }

        [PersonalData]
        [Display(Name = "ActualBalance")]
        public float ActualBalance { get; set; }

        [PersonalData]
        [Display(Name = "WithdrawalAmount")]
        public float WithdrawalAmount { get; set; }

        [PersonalData]
        [Display(Name = "DepositAmount")]
        public float DepositAmount { get; set; }

        [PersonalData]
        [Display(Name = "OtherAccount")]
        public string OtherAccount { get; set; }

        //User Foreign Key
        public int UserID { get; set; }
        public ApplicationUser User { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
