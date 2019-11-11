using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogEngineProject.Models;

namespace BlogEngineProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("About");
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult ThreadSearch()
        {
            return View();
        }

        public IActionResult MyBlog()
        {
            return View();
        }
    }
}
