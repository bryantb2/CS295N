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

        public IActionResult MyBlogDashboard()
        {
            // no need to valid tempdata, only time this method gets called is if a valid username is passed
            string username = TempData["validUsername"].ToString();
            User userObject = UserRepo.GetUserByUsername(username);

            return View("MyBlogMainPanel", userObject);
        }

        // these methods require a userId for access
        public IActionResult ReloadBlogDashboard()
        {
            // takes in userId from temp data entry
            // retrieves user object and then passes it into the dashboard view
            int userId = int.Parse(TempData["userId"].ToString());
            User userObject = UserRepo.GetUserById(userId);

            return View("MyBlogMainPanel", userObject);
        }
        
        public RedirectToActionResult AddPost(string postTitle, string postContent, string threadId, string userId)
        {
            // Build post object
            // Get thread by id
            // add post to thread
            // make a temp data entry containing the userId
            // redirect to ReloadBlogDashboard action method

            Post newPost = new Post()
            {
                PostID = ObjectIDBuilder.GetPostID(),
                Title = postTitle,
                Content = postContent
            };

            int THREADID = int.Parse(threadId);
            ThreadRepo.GetThreadById(THREADID).AddPostToThread(newPost);

            TempData["userId"] = userId;
            return RedirectToAction("ReloadBlogDashboard");
        }

        public RedirectToActionResult RemovePost(string postId, string threadId, string userId)
        {
            // get thread by id
            // remove the post from thread
            // make a temp data entry containing the userId
            // redirect to ReloadBlogDashboard action method
            int POST_ID = int.Parse(postId);
            int THREAD_ID = int.Parse(threadId);

            Thread thread = ThreadRepo.GetThreadById(THREAD_ID);
            thread.RemovePostFromHistory(POST_ID);

            TempData["userId"] = userId;
            return RedirectToAction("ReloadBlogDashboard");
        }

        public IActionResult PostEditor(string postId, string userId)
        {
            return View();
        }

        public IActionResult PostDashboard(string userId)
        {
            // get user by id
            // pass user object into view
            int ID = int.Parse(userId);
            User userObject = UserRepo.GetUserById(ID);

            return View(userObject);
        }

        public IActionResult EditProfile(string userId)
        {
            return View();
        }

        public IActionResult GettingStarted(string userId)
        {
            return View();
        }

    }
}