using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngineProject.Controllers
{
    public class MyBlogController : Controller
    {
        public IActionResult Index()
        {
            if (TempData["SignUpMessage"] != null)
            {
                // if message tempdata entry is not null, pass the message to the view
                ViewBag.ErrorMessage = TempData["SignUpMessage"];
            }
            return View("MyBlogSignIn");
        }

        public IActionResult SignUp()
        {
            return View("MyBlogSignUp");
        }
        
        public RedirectToActionResult SignUpRedirect(string username, string password)
        {
            // validate username and password (not empty AND trim trailing white space)
            // search repo for username
            // if username and password match
            // redirect to myblogpanel
            // else show signup with an invalid username and password error
            var trimmedUsername = "";
            var trimmedPassword = "";

            if (username != null && password != null)
            {
                trimmedUsername = username.Trim();
                trimmedPassword = password.Trim();
            }
            else
            {
                // create a tempdata entry that contains the message to be returned in the sign up view
                // return signup view because the password/username combo is not valid
                TempData["SignUpMessage"] = "Password and/or username fields cannot be empty";
                return RedirectToAction("Index");
            }



            TempData["SignUpMessage"] = "Please enter a valid username and/or password. If you are not a user, sign up!";
            return RedirectToAction("MyBlogDashboard");
        }

        public IActionResult PostDashboard()
        {
            return View();
        }

        public IActionResult PostEditor()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult GettingStarted()
        {
            return View();
        }

        public IActionResult MyBlogDashboard()
        {
            return View("MyBlogMainPanel");
        }
    }
}