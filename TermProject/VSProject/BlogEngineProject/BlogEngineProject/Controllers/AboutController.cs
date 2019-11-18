﻿using System;
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
            /* 
               this is the first action method to fire when the website loads, therefore it will be the place that
               the thread and user repos are filled 
            */
            RepoFiller.FillRepos();
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