using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Planiture_Website.Models;

namespace Planiture_Website.Areas.Identity.Pages.Account.Manage
{
    public class TransactionsModel : PageModel
    {

        public IActionResult OnGet()
        {
            //database coonection string
            string connectString = connectString = "Data Source=MSI;Initial Catalog=Planiture_Records;Integrated Security=True";

            string sql = "select * from UserAccount";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand cmd = new SqlCommand(sql, connect);

            var model = new List<Account_Info>();
            using (connect)
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var account = new Account_Info();
                    account.AccountName = (string)reader["AccountName"];

                    model.Add(account);
                }
            }
            return Page();
        }

    }
}
