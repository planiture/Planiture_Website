using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Planiture_Website.Models;

namespace Planiture_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult Investments()
        {
            return View();
        }

        public IActionResult Subscriptions()
        {
            return View();
        }

        public IActionResult PlanitureAcademy()
        {
            return View();
        }

        public IActionResult Policy()
        {
            return View();
        }

        public IActionResult CustomerService()
        {
            return View();
        }

        public IActionResult Career()
        {
            return View();
        }

        public IActionResult CustomerServiceJob()
        {
            return View();
        }

        public IActionResult MarketAnalyzerJob()
        {
            return View();
        }

        public IActionResult SocialMediaManagerJob()
        {
            return View();
        }

        public IActionResult UploadApprovedDocument()
        {
            return View();
        }

        public IActionResult Store()
        {
            return View();
        }

        public IActionResult InformationCenter()
        {
            return View();
        }

        public IActionResult AccountOptions()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GoldenInvestorApplication()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GoldenInvestorApplication(Investment_Info invest)
        {
            if(ModelState.IsValid)
            {
                var kingz = new ApplicationUser()
                {
                    /*FormType = "Golden Investor", //this is currently hardcoded... it this later
                    Ques1 = invest.Ques1,
                    Ques2 = invest.Ques2,
                    Ques3 = invest.Ques3,
                    Ques4 = invest.Ques4,
                    Ques5 = invest.Ques5,
                    Ques6 = invest.Ques6,
                    Ben_FirstName = invest.Bene_FirstName,
                    Ben_LastName = invest.Bene_LastName,
                    Ben_Contact = invest.Bene_Contact,
                    Ben_Relationship = invest.Bene_Relationship,
                    Ben_Email = invest.Bene_Email,
                    Ben_Address = invest.BenAddress,
                    CusSignature = invest.Signature,*/
                    
                };

                //Add way to pass info to table
                //_context.Investment_Info.Update(invest);

                _logger.LogInformation("User Beneficiary and investment background added.");

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult BasicAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BasicAccount(Investment_Info invest)
        {
            if (ModelState.IsValid)
            {
                var kingz = new ApplicationUser()
                {
                    /*FormType = "Basic Account", //this is currently hardcoded... it this later
                    Ques1 = invest.Ques1,
                    Ques2 = invest.Ques2,
                    Ques3 = invest.Ques3,
                    Ques4 = invest.Ques4,
                    Ques5 = invest.Ques5,
                    Ques6 = invest.Ques6,
                    Ben_FirstName = invest.Bene_FirstName,
                    Ben_LastName = invest.Bene_LastName,
                    Ben_Contact = invest.Bene_Contact,
                    Ben_Relationship = invest.Bene_Relationship,
                    Ben_Email = invest.Bene_Email,
                    Ben_Address = invest.BenAddress,
                    CusSignature = invest.Signature,*/

                };

                //Add way to store info in table
                //_context.Investment_Info.Update(invest);

                _logger.LogInformation("User Beneficiary and investment background added.");

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult TradersAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TradersAccount(Investment_Info invest)
        {
            if (ModelState.IsValid)
            {
                var kingz = new ApplicationUser()
                {
                    /*FormType = "Golden Investor", //this is currently hardcoded... it this later
                    Ques1 = invest.Ques1,
                    Ques2 = invest.Ques2,
                    Ques3 = invest.Ques3,
                    Ques4 = invest.Ques4,
                    Ques5 = invest.Ques5,
                    Ques6 = invest.Ques6,
                    Ben_FirstName = invest.Bene_FirstName,
                    Ben_LastName = invest.Bene_LastName,
                    Ben_Contact = invest.Bene_Contact,
                    Ben_Relationship = invest.Bene_Relationship,
                    Ben_Email = invest.Bene_Email,
                    Ben_Address = invest.BenAddress,
                    CusSignature = invest.Signature,*/

                };

                //Add a way to save info to table
                //_context.Investment_Info.Update(invest);

                _logger.LogInformation("User Beneficiary and investment background added.");

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AdvancedAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdvancedAccount(Investment_Info invest)
        {
            if (ModelState.IsValid)
            {
                var kingz = new ApplicationUser()
                {
                    /*FormType = "Golden Investor", //this is currently hardcoded... it this later
                    Ques1 = invest.Ques1,
                    Ques2 = invest.Ques2,
                    Ques3 = invest.Ques3,
                    Ques4 = invest.Ques4,
                    Ques5 = invest.Ques5,
                    Ques6 = invest.Ques6,
                    Ben_FirstName = invest.Bene_FirstName,
                    Ben_LastName = invest.Bene_LastName,
                    Ben_Contact = invest.Bene_Contact,
                    Ben_Relationship = invest.Bene_Relationship,
                    Ben_Email = invest.Bene_Email,
                    Ben_Address = invest.BenAddress,
                    CusSignature = invest.Signature,*/

                };
                //Add a method to save the data to table

                //_context.ApplicationUser.Update(invest);
                _logger.LogInformation("User Beneficiary and investment background added.");

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
