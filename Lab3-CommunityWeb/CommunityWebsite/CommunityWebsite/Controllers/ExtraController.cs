using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebsite.Models;

namespace CommunityWebsite.Controllers
{
    public class ExtraController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.BackgroundStyle = "pageContainer";
            return View();
        }

        public String Okay()
        {
            return ("okay, you found me!");
        }

        public UnauthorizedResult BadSignin()
        {
            return Unauthorized();
        }

        public AcceptedResult GoodResult()
        {
            return Accepted();
        }

        public JsonResult ReturnUsers()
        {
            FakeUserRepo userRepo = new FakeUserRepo();
            User newUser = new User("bob");
            newUser.Password = "nice-Try-FBI!";
            userRepo.AddNewUser(newUser);
            var jsonObject = userRepo.ListOfUsers;

            return Json(jsonObject);
        }
    }
}