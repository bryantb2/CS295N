﻿using System;
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
            List<User> listOfUsers = UserList.ListOfUsers;
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
            TempData["chatRoom"] = topic;
            if(topic == "general")
            {
                TempData["pageTitleText"] = "General Messageboard";
            }
            else
            {
                TempData["pageTitleText"] = "Star Wars Messageboard";
            }
            return RedirectToAction("Forum");
        }

        
        public RedirectToActionResult GeneralForum()
        {
            //set the genre the user selected for retrieval later
            TempData["chatRoom"] = "general";
            TempData["pageTitleText"] = "General Messageboard";
            return RedirectToAction("Forum");
        }


        public RedirectToActionResult StarwarsForum()
        {
            //set the genre the user selected for retrieval later
            TempData["chatRoom"] = "starwars";
            TempData["pageTitleText"] = "Star Wars Messageboard";
            return RedirectToAction("Forum");
        }

        public IActionResult Forum()
        {
            Messaging.SortMessagesByDate(TempData["chatRoom"].ToString());
            ViewBag.BackgroundStyle = "pageContainer7";
            ViewBag.SelectedChat = TempData["chatRoom"];
            ViewBag.TitleText = TempData["pageTitleText"];
            List<Message> messageBoardContent = Messaging.GetMessageList(TempData["chatRoom"].ToString());
            return View("Forum", messageBoardContent);
        }

        //METHODS FOR REPLY SYSTEM

        [HttpPost]
        public RedirectToActionResult ReplyButtonSubmit(string parentMessageID, string chatGenre)
        {
            //method takes the message ID of message being replied to AND the current chat thread
            //will make it temp data so it can be used in the ReplyForm action
            TempData["originalMessage"] = parentMessageID;
            TempData["discussionThread"] = chatGenre;
            return RedirectToAction("ReplyForm");
        }

        public IActionResult ReplyForm()
        {
            //ReplyForm needs a parent message ID because it tells the code which comment the reply belongs to
            
            //get the messageID
            //get the discussion genre (make it easier to search the messageboard content)
            int messageID = int.Parse(TempData["originalMessage"].ToString());
            string threadGenre = TempData["discussionThread"].ToString();

            //search the messageboard to find the original message object
            Message originalMessage = Messaging.getMessageFromBoard(threadGenre, messageID);

            //Viewbag for background image
            ViewBag.BackgroundStyle = "pageContainer8";

            //pass in original message to be parsed and used
            return View(originalMessage);
        }

        [HttpPost]
        public RedirectToActionResult GenerateReply(string replyMessageContent, string poster, string chatGenre, string parentMessageID)
        {
            //CALLED WHEN the user submits a completed reply form from the ReplyForm view
            //REDIRECTS TO the main forum page, which will load the new reply

            //check if replier's username exists
                //add to userlist if not
            //generate reply
            //add reply to message in forum (via MessageBoard)
            //add reply to poster's history (via userlist)
            //add reply to the reply list of the original MESSAGE (via userlist)

            User newUser;
            Reply reply;
            List<User> listOfUsers = UserList.ListOfUsers;
            bool userExists = false;

            foreach (User u in listOfUsers)
            {
                //checking database to user if the username already exists
                if (u.Username == poster)
                {
                    userExists = true;  //this means that the user has been found in the "database"
                }
            }
            if(userExists != true)
            {
                //create new user
                //add user to Userlist
                newUser = new User(poster);
                UserList.AddNewUser(newUser);
            }

            //building old message object to grab important info such as usernames (easier than passing around a bunch of view form data)
            int OGMessageID = int.Parse(parentMessageID);
            Message message = Messaging.getMessageFromBoard(chatGenre, OGMessageID);
            string OGCommenter = message.UserNameSignature;
            
            //instantiating reply object
            reply = new Reply(replyMessageContent, poster);

            Messaging.findAndAddToMessageReplies(chatGenre, OGMessageID, reply);
            UserList.ModifyUserReplyHistory(poster, "add", reply);
            //UserList.AddReplyToMessage(OGCommenter, OGMessageID, reply);

            //determine which chatRoom will be displayed in the form when called
            //determines what the title text will be
            //determines the which message list gets sorted
            if(chatGenre == "general")
            {
                TempData["chatRoom"] = "general";
                TempData["pageTitleText"] = "General Messageboard";
            }
            else if(chatGenre == "starwars")
            {
                TempData["chatRoom"] = "starwars";
                TempData["pageTitleText"] = "Star Wars Messageboard";
            }
            else
            {
                throw new ArgumentException("please enter a valid chatRoomGenre");
            }
                

            


            //set reply object in the REPLIER's reply history
            /*
            UserList.AddToUserReplyHistory(poster, reply);


            //set reply object in comment's reply list
            //sync message replies with OG POSTER's reply history (essentially add the reply to comment of the actual commenter)
            oldMessage.AddToReplyHistory(reply);
            UserList.FindAndReplaceUserMessage(oldMessage.UserNameSignature, int.Parse(parentMessageID), oldMessage);
            Messaging.findAddReplaceMessage(chatGenre, int.Parse(parentMessageID), oldMessage);*/

            return RedirectToAction("Forum");
        }

    }
}