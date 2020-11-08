using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using Planiture_Website.Models;

namespace Planiture_Website.Areas.Identity.Pages.Account.Manage.Live_Chat
{
    public class AgentLoginModel : PageModel
    {
        private readonly ILogger<AgentLoginModel> _logger;
        private ApplicationDbContext _context;

        public AgentLoginModel(ILogger<AgentLoginModel> logger,
            ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string username { get; set; }
            [DataType(DataType.Password)]
            public string password { get; set; }
        }

        public IActionResult OnGet()
        {
            /*var key = "AgentCookie";
            var cookie = Request.Cookies[key];
            if(cookie == "AlreadyLoggedIn")
            {
                return RedirectToPage("Chat");
            }
            else
            {
                return Page();
            }*/
            return Page();
        }

        public IActionResult OnPostAsync(ConfigFile confile)
        {
            if (ModelState.IsValid)
            {
                
                var provider = new SHA1CryptoServiceProvider();
                var encoding = new UnicodeEncoding();
                if(Input.password != null)
                {
                    var tempstore = Convert.ToBase64String(provider.ComputeHash(encoding.GetBytes(Input.password)));

                    SqlConnection con = new SqlConnection(@"Data Source=MSI;Initial Catalog=LiveChat;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select AdminPass, AgentPass from ConfigFiles", con);
                    List<string> str = new List<string>();
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        str.Add(da.GetValue(0).ToString());
                        str.Add(da.GetValue(1).ToString());
                    }
                    con.Close();

                    if ((str[0] == tempstore) || (str[1] == tempstore))
                    {
                        string key = "AgentCookie";
                        string value = "AlreadyLoggedIn";
                        CookieOptions cookieOptions = new CookieOptions();
                        cookieOptions.Expires = DateTime.Now.AddMinutes(2);
                        Response.Cookies.Append(key, value, cookieOptions);

                        //return RedirectToPage("Chat");
                    }
                }
            }
            return Page();
        }
    }
}
