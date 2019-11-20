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

        // Unit testing methods
        public int Divide(int number1, int number2)
        {
            return (number1 / number2);
        }

        public String ReturnPostTitleObject(Message message)
        {
            return message.MessageTitle;
        }

        public int GetNumberOfRepliesOnMessage(Message message)
        {
            return message.GetReplyHistory.Count;
        }

        public bool DoesMessageHaveReplies(Message message)
        {
            return (message.GetReplyHistory.Count > 0 ? true : false);
        }
    }
}