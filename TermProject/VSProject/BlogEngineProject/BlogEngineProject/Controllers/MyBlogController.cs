using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogEngineProject.Models;

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
                // return signup view because the password/username combo is empty
                TempData["SignUpMessage"] = "Password and/or username fields cannot be empty";
                return RedirectToAction("Index");
            }

            bool areCredentialsValid = UserRepo.CheckUserCredentials(trimmedUsername, trimmedPassword);
            if(areCredentialsValid != true)
            {
                // create a tempdata entry that contains the message to be returned in the sign up view
                // return signup view because the password/username combo is not valid
                TempData["SignUpMessage"] = "Password and/or username fields are incorrect. If are not a user already, then sign up!";
                return RedirectToAction("Index");
            }

            TempData["validUsername"] = trimmedUsername;
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
            User userObject = null;
            string username = TempData["validUsername"].ToString();
            if (username != null)
            {
                // if validUsername tempdata entry is not null, get userByUsername and pass object to the view
                userObject = UserRepo.GetUserByUsername(username);
            }
            return View("MyBlogMainPanel", userObject);
        }
    }
}