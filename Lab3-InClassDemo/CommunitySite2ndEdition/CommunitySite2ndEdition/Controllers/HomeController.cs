using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCServeciesApp.Controllers
{
    public class HomeController : Controller
    {
        /* Change return type to String */

        public IActionResult Index()

        {

            /* Return a literal string instead of calling view() */

            return View("Index","Hello there");

        }
    }
}