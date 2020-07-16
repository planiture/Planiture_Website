﻿using Microsoft.AspNetCore.Identity;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Threading.Tasks;
using System.Transactions;

namespace Planiture_Website.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        //Info for Customer_Info table
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DOB { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
        public DateTime MemberSince { get; set; }

        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string Residency { get; set; }
        public string Signature { get; set; }

        /*//Info for InvestmentQuestion table
        public string FormType { get; set; }
        public string Ques1 { get; set; }
        public string Ques2 { get; set; }
        public string Ques3 { get; set; }
        public string Ques4 { get; set; }
        public string Ques5 { get; set; }
        public string Ques6 { get; set; }

        //Info for Beneficiary_Info table
        public string Ben_FirstName { get; set; }
        public string Ben_LastName { get; set; }
        public string Ben_Contact { get; set; }
        public string Ben_Relationship { get; set; }
        public string Ben_Email { get; set; }
        public string Ben_Address { get; set; }
        //public string Ben_CustomerID { get; set; }

        //Info for Account_Info table
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public float AvailableBalance { get; set; }
        public float ActualBalance { get; set; }
        public float WithdrawalAmount { get; set; }
        public float DepositAmount { get; set; }
        public string OtherAccount { get; set; }
        //public string Acc_CustomerID { get; set; }

        //Info for Employee_Info table
        public string Trans_EmployeeID { get; set; }
        public string Emp_FirstName { get; set; }
        public string Emp_LastName { get; set; }
        public string Emp_UserName { get; set; }
        public string Emp_Password { get; set; }
        public string Emp_Old_Password { get; set; }
        public string ReportsTo { get; set; }

        //Info for CusTransaction table
        public float TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public string  Trans_AccountNumber { get; set; }
        public string Trans_OtherAccount { get; set; }
       // public string Trans_CustomerID { get; set; }
        //public string Trans_EmployeeID { get; set; }
        public string ApprovedBy { get; set; }
        public string Trans_TransactionStatus { get; set; }*/

        //Provide Concurrency
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
