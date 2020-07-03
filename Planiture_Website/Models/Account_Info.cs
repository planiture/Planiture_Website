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
        [Required]
        [Display(Name = "AccountName")]
        public string AccountName { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "AccountType")]
        public string AccountType { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "AvailableBalance")]
        public float AvailableBalance { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "ActualBalance")]
        public float ActualBalance { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "WithdrawalAmount")]
        public float WithdrawalAmount { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "DepositAmount")]
        public float DepositAmount { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "OtherAccount")]
        public string OtherAccount { get; set; }

        public string Acc_CustomerID { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        //Customer_Info Foreign Key
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public InputModel Customer_Info { get; set; }

        public ICollection<CusTransaction> cusTransactionsAccount { get; set; }
    }
}
