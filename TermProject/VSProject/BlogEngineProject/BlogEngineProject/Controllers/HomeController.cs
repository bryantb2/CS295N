﻿using System;
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
        public IActionResult Index(int category=-1)
        {
            // Get thread objects
            // check if search results have already been queued
            // Pass thread list into Home
            List<Thread> threadList;
            if (category != -1)
            {
                threadList = ThreadRepo.GetCategoryOfThreads(category);
            }
            else
            {
                threadList = ThreadRepo.GetThreads();
            }
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

        public IActionResult ViewBlog(int threadID = -1)
        {
            Thread searchResult;
            if(threadID != -1)
            {
                // search for the thread by name
                searchResult = ThreadRepo.GetThreadById(threadID);
            }
            else
            {
                // returns to thread page if no parameter values are found
                return View("Index");
            }
            return View(searchResult);
        }

        // specific get request or related actions
        /*public RedirectToActionResult GetCategoryThreads(int category)
        {
            //int categoryAsInt = int.Parse(category);
            List<Thread> searchResults = ThreadRepo.GetCategoryOfThreads(category);
            TempData["searchResults"] = searchResults;
            return RedirectToAction("Index");
        }*/
    }
}
