using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Data;
using Microsoft.OData.Edm;
using Planiture_Website.Data;
using Planiture_Website.Controllers;
using System.ComponentModel.DataAnnotations.Schema;
using Planiture_Website.Models;

namespace Planiture_Website.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender; //need to format this 
        private readonly ApplicationDbContext _context; //just added

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context; //just added
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }




        public class InputModel
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int CustomerID { get; set; } 

            //Personal Information
            [PersonalData]
            //[Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [PersonalData]
            //[Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [PersonalData]
            [Display(Name = "DOB")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime DOB {get; set;}

            [PersonalData]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
            public DateTime MemberSince { get; set; }


            [PersonalData]
            [Display(Name = "Gender")]
            public string Gender { get; set; }

            [PersonalData]
            //[Required]
            [Display(Name = "Occupation")]
            public string Occupation { get; set; }

            [PersonalData]
            //[Required]
            [Display(Name = "Prefix")]
            public string Prefix { get; set; }

            [PersonalData]
            //[Required]
            [Display(Name = "Mobile")]
            public string Mobile { get; set; }

            [PersonalData]
            //[EmailAddress]
            public string Email { get; set; }

            [PersonalData]
            //[Required]
            [Display(Name = "Address")]
            public string CusAddress { get; set; }

            [PersonalData]
            [Display(Name = "Residency")]
            public string Residency { get; set; }

            //[Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            //[Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Timestamp]
            public byte[] RowVersion { get; set; }

            public ICollection<Investment_Info> Bene_Investments { get; set; }
            public ICollection<Account_Info> Accounts { get; set; }
            public ICollection<CusTransaction> cusTransactionsCustomer { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            string catadd = "(" +Input.Prefix +")"+ Input.Mobile;

            //DateTime tempDate = Input.DOB.

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    CusFirstName = Input.FirstName,
                    CusLastName = Input.LastName,
                    CusDOB = Input.DOB,
                    CusGender = Input.Gender,
                    CusOccupation = Input.Occupation,
                    CusMobile = catadd,
                    CusUserRole = "Customer",
                    CusEmail = Input.Email,
                    CusAddress = Input.CusAddress,
                    CusResidency = Input.Residency,
                    Cus_UserName = Input.Username,
                    //CusPassword = Input.Password,
                    //Cus_ConfirmPassword = Input.ConfirmPassword,
                };

                var result = await _userManager.CreateAsync(user, Input.Password);





                //_logger.LogInformation("User account created a new account with password.");

                //_context.Customer_Info.Add(Input);
                //_context.Add(log);


                //await _context.SaveChangesAsync();
                //return RedirectToAction("AccountOptions", "Home");
                //return LocalRedirect("Index");

            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

    }
}
