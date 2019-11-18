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
                // check if search results have already been queued
            // Pass thread list into Home
            List<Thread> threadList;
            if (TempData["searchResults"] != null)
                threadList = (List<Thread>)TempData["searchResults"];
            else
                threadList = ThreadRepo.GetThreads();
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

        // specific get request or related actions
        public RedirectToActionResult GetCategoryThreads(string category)
        {
            int categoryAsInt = int.Parse(category);
            List<Thread> searchResults = ThreadRepo.GetCategoryOfThreads(categoryAsInt);
            TempData["searchResults"] = searchResults;
            return RedirectToAction("Index");
        }
    }
}
