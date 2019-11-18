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
            // Get thread objects
            // Pass thread list into Home
            List<Thread> threadList = ThreadRepo.GetThreads();
            return View("Home",threadList);
        }

        public IActionResult ReplyToPost()
        {
            return View();
        }

        public IActionResult ThreadSearch()
        {
            return View();
        }

        public IActionResult ThreadSearchResults(string searchParameter)
        {
            return View();
        }

        public IActionResult ViewBlog()
        {
            return View();
        }
    }
}
