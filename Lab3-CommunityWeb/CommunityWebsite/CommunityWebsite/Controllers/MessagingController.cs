using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebsite.Models;

namespace CommunityWebsite.Controllers
{
    public class MessagingController : Controller
    {
        
        public IActionResult Index()
        {
            return View("Forum");
        }

        [HttpPost]
        public RedirectToActionResult GenerateMessage(string messageTitle, string topic, string userName,
            string messageContent)
        {
            User newUser;
            Message newMessage;
            List<User> listOfUsers = UserList.GetListOfUsers;
            bool userExists = false;
            
            foreach (User u in listOfUsers)
            {
                //checking database to user if the username already exists
                if(u.Username == userName)
                {
                    userExists = true;  //this means that the user has been found in the "database"
                }
            }
            //sets topic to the appropriate input string for the model
            if (topic == "generalChat")
            {
                topic = "general";
            }
            else
            {
                topic = "starwars";
            }
            if (userExists != true)
            {
                //assumes that user does not exist in "database"
                //build a user
                //add user to user list
                //build a message
                //add to messaging history of the user
                //add message to messsage board
                newUser = new User(userName);
                newMessage = new Message(messageTitle, messageContent, userName, topic);
                newUser.AddMessageToHistory(newMessage);
                UserList.AddNewUser(newUser);
                Messaging.addMessageToBoard(topic, newMessage);
            }
            else
            {
                //assumes that the user already exists in the database
                //build message
                //add to message history of the user 
                /*
                    this is done by passing the desired username into the FindUser method in the userlist static class
                    the method will return either -1, meaning the user was not found, or the index of the element the user exists in
                */
                //add message to message board
                newMessage = new Message(messageTitle, messageContent, userName, topic);
                UserList.ModifyUserMessageHistory(userName, "add", newMessage);
                Messaging.addMessageToBoard(topic,newMessage);
            }
            return RedirectToAction("Index");
        }

        
        public IActionResult ReplyForm()
        {
            return View("ReplyForm");
        }

        [HttpPost]
        public RedirectToActionResult GenerateReply()
        {
            return RedirectToAction("Index");
        }

    }
}