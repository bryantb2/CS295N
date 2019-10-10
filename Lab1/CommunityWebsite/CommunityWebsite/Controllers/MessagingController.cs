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
            return View();
        }

        [HttpPost]
        public RedirectToActionResult GenerateModelObjects(string topic, string userName,string password,string passwordConfirmed,
            string messageContent)
        {
            //build a user
            //add user to user list
            //build a message
            //add to messaging history of the user
            //add message to messsage board
            User newUser;
            Message newMessage;
            List<User> listOfUsers = UserList.GetListOfUsers;
            bool userExists = false;
            foreach(User u in listOfUsers)
            {
                //if the user does not already exist (validation done before building user object
                if((u.Username == userName && u.Password == password))
                {
                    //sets topic to the appropriate input string for the model
                    if(topic=="generalChat")
                    {
                        topic = "general";
                    }
                    else
                    {
                        topic = "starWars";
                    }
                    newUser = new User(userName, password);
                    newMessage = new Message(messageContent, userName, topic);
                    newUser.AddMessageToHistory(newMessage);
                    UserList.AddNewUser(newUser);
                    MessageBoard.addMessageToBoard(topic, newMessage);
                    userExists = true;  //this means that the user has been entered into the "database"
                }
            }
            if(userExists != true)
            {
                //assumes that user already exists, and therefore userCreated is false
            }
        }

    }
}