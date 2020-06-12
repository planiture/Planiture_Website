using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Planiture_Website.Models;

namespace Planiture_Website.Controllers
{
    public class UploadSignDocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetDocumentInfo()
        {
            //just trying a thing
            UploadSignDocumentClass obj = new UploadSignDocumentClass();

            return View(obj);
        }

    }
}