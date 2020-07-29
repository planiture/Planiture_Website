using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Planiture_Website.Models;

namespace Planiture_Website.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public ProfileController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

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

        //advanced account user profile
        public IActionResult AdvancedProfile()
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

        //Stocks account user profile
        public IActionResult StocksProfile()
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

        //Golden20 account user profile
        public IActionResult Golden20Profile()
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

    }
}
