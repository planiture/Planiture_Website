using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Planiture_Website.Models;

namespace Planiture_Website.Controllers
{
    public class ProfileController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserInfo()
        {
            
            return View();
        }
    }
}
