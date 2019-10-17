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
        [HttpPost]
        public RedirectToActionResult GenerateMessage(string messageTitle, string topic, string userName, string messageContent)
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
            //set the genre the user selected for retrieval later
            Messaging.SelectedGenre = topic;
            return RedirectToAction("Forum");
        }

        
        public RedirectToActionResult GeneralForum()
        {
            //set the genre the user selected for retrieval later
            Messaging.SelectedGenre = "general";
            return RedirectToAction("Forum");
        }

        
        public RedirectToActionResult StarwarsForum()
        {
            //set the genre the user selected for retrieval later
            Messaging.SelectedGenre = "starwars";
            return RedirectToAction("Forum");
        }

        public IActionResult Forum()
        {
            ViewBag.BackgroundStyle = "pageContainer7";
            List<Message> messageBoardContent = Messaging.GetMessageList(Messaging.SelectedGenre);
            return View("Forum", messageBoardContent);
        }

        //METHODS FOR REPLY SYSTEM

        [HttpPost]
        public RedirectToActionResult ReplyButtonSubmit(string parentMessageID, string chatGenre)
        {
            //method takes the message ID of message being replied to and passes a complete comment object into the reply form
            TempData["originalMessage"] = parentMessageID;
            TempData["discussionThread"] = chatGenre;
            return RedirectToAction("ReplyForm", parentMessageID);
        }

        public IActionResult ReplyForm()
        {
            //ReplyForm needs a parent message ID because it tells the code which comment the reply belongs to
            
            //get the messageID
            //get the discussion genre (make it easier to search the messageboard content)
            int messageID = int.Parse(TempData["originalMessage"].ToString());
            string threadGenre = TempData["discussionThread"].ToString();

            //search the messageboard to find the original message object
            Message originalMessage = Messaging.findMessageFromBoard(threadGenre, messageID);

            //pass in original message to be parsed and used
            return View("ReplyForm", originalMessage);
        }

        [HttpPost]
        public RedirectToActionResult GenerateReply(string messageContent, string usernameSignature)
        {
            //called when the user submits a completed reply form from the ReplyForm view
            //redirects to the main forum page, which will load the new reply

            //get reply data
            //build a reply object
            //set reply object in the replier's reply history
            //set reply object in comment's reply list
            //set reply in UserList

            return RedirectToAction("Forum");
        }

    }
}