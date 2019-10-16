using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebsite.Models;

namespace CommunityWebsite.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Info()
        {
            ViewBag.BackgroundStyle = "pageContainer4";
            return View("Info");
        }

        public IActionResult Locations()
        {
            ViewBag.BackgroundStyle = "pageContainer5";
            return View("Locations");
        }

        public IActionResult SignificantPeople()
        {
            ViewBag.BackgroundStyle = "pageContainer6";
            return View("SignificantPeople");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}