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
using Planiture_Website.Models;

namespace Planiture_Website.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            //Personal Information
            [PersonalData]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [PersonalData]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [PersonalData]
            [Display(Name = "DOB")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime DOB { get; set; }

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

            /*[PersonalData]
            [Display(Name = "Area Code")]
            public string AreaCode { get; set; }*/

            [PersonalData]
            [Display(Name = "Mobile")]
            public string Mobile { get; set; }

            [PersonalData]
            [EmailAddress]
            public string Email { get; set; }

            [PersonalData]
            [Display(Name = "Address")]
            public string CusAddress { get; set; }

            [PersonalData]
            [Display(Name = "Residency")]
            public string Residency { get; set; }

            
            [Display(Name = "Username")]
            public string Username { get; set; }

            
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
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser 
                { 
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    DOB = Input.DOB,
                    Address = Input.CusAddress,
                    PhoneNumber = Input.Mobile,
                    Gender = Input.Gender,
                    Occupation = Input.Occupation,
                    Residency = Input.Residency,
                    UserName = Input.Username,
                    Email = Input.Email 
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("New user account successfully created.");

                    //Create User/Customer role *Default role*
                    var role = new ApplicationRole();
                   role.Name = "Customer";
                   await _roleManager.CreateAsync(role);

                    //Add new user to the default role
                    var addrole = await _userManager.AddToRoleAsync(user, "Customer");
                    _logger.LogInformation("User role added.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        "<h1>Please confirm your email address</h1> <p>Hi"+Input.Username+", Please confirm your account by <a role='button' href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.</p>");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
