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
            //get and pass in location class object
            Locations locationPage = new Locations();
            ViewBag.BackgroundStyle = "pageContainer5";
            return View("Locations", locationPage);
        }

        public IActionResult SignificantPeople()
        {
            //get and pass in significantPeople class object
            SignificantPeople peoplePage = new SignificantPeople();
            ViewBag.BackgroundStyle = "pageContainer6";
            return View("SignificantPeople", peoplePage);
        }
        
    }
}