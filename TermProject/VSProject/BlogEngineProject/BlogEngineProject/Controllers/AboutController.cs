using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngineProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View("About");
        }

        public IActionResult AdvancedFeatures()
        {
            return View();
        }

        public IActionResult GettingStarted()
        {
            return View();
        }
    }
}