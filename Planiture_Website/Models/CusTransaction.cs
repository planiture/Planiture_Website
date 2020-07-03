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
    public class CusTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "TransactionAmount")]
        public float TransactionAmount { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "TransactionType")]
        public string TransactionType { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "Trans_AccountNumber")]
        public string Trans_AccountNumber { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "Trans_OtherAccount")]
        public string Trans_OtherAccount { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "Trans_CustomerID")]
        public string Trans_CustomerID { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "Trans_EmployeeID")]
        public string Trans_EmployeeID { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "ApprovedBy")]
        public string ApprovedBy { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "Trans_TransactionStatus")]
        public string Trans_TransactionStatus { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        //Customer_Info Foreign Key
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public InputModel Customers { get; set; }

        //Account_Info Foreign Key
        public int AccountNumber { get; set; }
        [ForeignKey("AccountNumber")]
        public Account_Info Accounts { get; set; }

        //Employee_Info Foreign Key
        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public Employee_Info Employees { get; set; }


    }
}
