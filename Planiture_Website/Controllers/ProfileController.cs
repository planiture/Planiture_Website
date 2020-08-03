using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Planiture_Website.Models;

namespace Planiture_Website.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ProfileController> _logger;
        private readonly ApplicationDbContext _context;

        public ProfileController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ProfileController> logger,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public List<CusTransaction> getTransactions()
        {
            List<CusTransaction> list_transactions = _context.UserTransaction.ToList();
            return list_transactions;
        }

        //check which user profile to load
        /*public async Task<IActionResult> CheckProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            var account = new Account_Info();

            if(account.UserID == user.Id)
            {
                if(account.AccountType == "Basic Account")
                {
                    return RedirectToAction("Index", "Profile");
                }
                if(account.AccountType == "Advanced Account")
                {
                    return RedirectToAction("AdvancedProfile", "Profile");
                }
                if(account.AccountType == "Stocks Account")
                {
                    return RedirectToAction("StocksProfile", "Profile");
                }
                if(account.AccountType == "Golden20 Account")
                {
                    return RedirectToAction("Golden20Profile", "Profile");
                }
            }
            else
            {
                if(account.AccountType =="Basic Account")
                {
                    return RedirectToAction("Index", "Profile");
                }

                _logger.LogInformation("ID's do not match");
                return RedirectToAction("Index", "Home");
            }

            return View();
        }*/

        //basic account user profile
        public IActionResult Index()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            if(userid == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ApplicationUser user = _userManager.FindByIdAsync(userid).Result;
                return View(user);
            }
            
        }

        public IActionResult PersonalInfo()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            if (userid == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ApplicationUser user = _userManager.FindByIdAsync(userid).Result;
                return View(user);
            }
        }


        //Edit userprofile
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditUser
            {
                Id = user.Id,
                LastName = user.LastName,
                Email = user.Email,
                Occupation = user.Occupation,
                UserName = user.UserName,
                Gender = user.Gender,
                DOB = user.DOB,
                Address = user.Address,
                Residency = user.Residency
            };
            return View(model);
            
            /*ApplicationUser userlist = _context.UserInfo.Find(id);
            
            return View(userlist);*/

            /*var userid = _userManager.GetUserId(HttpContext.User);

            List<ApplicationUser> users = _context.UserInfo.ToList();
            int tempID = Convert.ToInt32(userid);

            return View(users.Find(p => p.Id == tempID));*/
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUser model)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Gender = model.Gender;
                user.DOB = model.DOB;
                user.Signature = model.Signature;
                user.Email = model.Email;
                user.Occupation = model.Occupation;
                user.Residency = model.Residency;

                var result = await _userManager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult Transactions()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            if (userid == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dynamic dy = new ExpandoObject();
                dy.transactionlist = getTransactions();
                return View(dy);
            }
            
        }

        public ActionResult GetAll()
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
                while(reader.Read())
                {
                    var account = new Account_Info();
                    account.AccountName = (string)reader["AccountName"];

                    model.Add(account);
                }
            }
            return View(model);
        }

    }
}
