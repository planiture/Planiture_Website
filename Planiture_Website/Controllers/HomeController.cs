using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult ContactUs()
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

        public IActionResult OurTeam()
        {
            return View();
        }

        public IActionResult IM_Academy()
        {
            return View();
        }

        public IActionResult IM_AcademyEarnLearn()
        {
            return View();
        }

        //Must have a user account with us to view
        //[Authorize(Roles = "Admin, Market_Analysis Rep_Access, Customer")]
        public IActionResult DailyBinarySignals()
        {
            return View();
        }

        //Must have a user account with us to view
        //[Authorize(Roles = "Admin, Market_Analysis Rep_Access, Customer")]
        public IActionResult Stocks()
        {
            return View();
        }

        public IActionResult OurAchievements()
        {
            return View();
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        //Customer Account Application Proccess

        
        public IActionResult CreateApplication()
        {
            return View();
        }

        public IActionResult AccountOptions()
        {
            return View();
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Golden20Application()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Golden20Application(Investment_Info invest)
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
                //Get the existing user from the database
                var user = await _userManager.GetUserAsync(User);

                //update it with the values from the investment_Info
                user.Signature = invest.Signature;
                await _userManager.UpdateAsync(user);
                _logger.LogInformation("User Signature info updated");


                //Update the foreign keys

                /*var userinvest = new UserInvestment_Info()
                {
                    InvestID = invest.ID,
                    UserID = user.Id,
                };*/
                

                invest.FormType = "Basic";
                _context.Investment_Info.Add(invest);
                _logger.LogInformation("User Beneficiary and investment background added.");
                //_context.UserInvestment_Infos.Add(userinvest);
                //_logger.LogInformation("Link between user info and investment info created");

                await _context.SaveChangesAsync();

                /*SqlConnection connect = new SqlConnection("Data Source=MSI;Initial Catalog=Planiture_Records;Integrated Security=True");

                connect.Open();
                string sqlquery = ("insert into [Investment_Info] (FormType,Ques1,Ques2,Ques3,Ques4,Ques5,Ques6,Signature,Bene_FirstName,Bene_LastName,Bene_Contact,Bene_Relationship,Bene_Email,BenAddress)" +
                    " values(@FormType,@Ques1,@Ques2,@Ques3,@Ques4,@Ques5,@Ques6,@Signature,@Bene_FirstName,@Bene_LastName,@Bene_Contact,@Bene_Relationship,@Bene_Email,@BenAddress)");
                SqlCommand cmd = new SqlCommand(sqlquery, connect);
                cmd.Parameters.AddWithValue("@FormType", "Basic");
                cmd.Parameters.AddWithValue("@Ques1", invest.Ques1);
                cmd.Parameters.AddWithValue("@Ques2", invest.Ques2);
                cmd.Parameters.AddWithValue("@Ques3", invest.Ques3);
                cmd.Parameters.AddWithValue("@Ques4", invest.Ques4);
                cmd.Parameters.AddWithValue("@Ques5", invest.Ques5);
                cmd.Parameters.AddWithValue("@Ques6", invest.Ques6);
                cmd.Parameters.AddWithValue("@Signature", invest.Signature);
                cmd.Parameters.AddWithValue("@Bene_FirstName", invest.Bene_FirstName);
                cmd.Parameters.AddWithValue("@Bene_LastName", invest.Bene_LastName);
                cmd.Parameters.AddWithValue("@Bene_Contact", invest.Bene_Contact);
                cmd.Parameters.AddWithValue("@Bene_Relationship", invest.Bene_Relationship);
                cmd.Parameters.AddWithValue("@Bene_Email", invest.Bene_Email);
                cmd.Parameters.AddWithValue("@BenAddress", invest.BenAddress);

                cmd.ExecuteNonQuery();
                connect.Close();*/

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
