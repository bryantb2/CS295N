using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebsite.Models;


namespace CommunityWebsite.Controllers
{
    //"has a..." is composition
    //"is a..." is inheritence
    public class HomeController : Controller
    {
        //THESE ARE ACTION METHODS
        public IActionResult Home()
        {
            ViewBag.BackgroundStyle = "pageContainer";
            return View("Home");
        }

        public IActionResult History()
        {
            ViewBag.BackgroundStyle = "pageContainer2";
            return View("History");
        }

        public IActionResult Contact()
        {
            ViewBag.BackgroundStyle = "pageContainer2";
            return View("Contact");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
