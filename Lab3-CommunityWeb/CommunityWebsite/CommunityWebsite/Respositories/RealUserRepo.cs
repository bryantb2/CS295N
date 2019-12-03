using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebsite.Respositories
{
    public class RealUserRepo : IUserRepo
    {
        // CLASS FIELDS
        private AppDbContext context;

        // CONSTRUCTOR
        public RealUserRepo(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        // PROPERTIES
        public List<User> ListOfUsers { get { return context.Users.ToList(); } }
        public int NumberOfUsers { get { return context.Users.ToList().Count; } }

        // METHODS
        /* this series of method will modify the message or reply history of a USER */
        public void ModifyUserMessageHistory(string userName, string operation, Message newMessage = null, int messageID = -1)
        {
            //GENERAL INFO:
            //username and operation must be defined ALWAYS
            //set newMessage to null if removing and to a valid object if adding
            //messageID is set to -1 by default if the operation is not remove

            //validation of non-operation specific parameters
            int elementIndex = this.FindUserIndex(userName);
            if (elementIndex == -1)
                throw new ArgumentException("Username is not valid or does not exist in the UserList collection");
            if (!(operation == "add" || operation == "remove"))
                throw new ArgumentException("Enter a valid operation; either string 'add' or string 'remove'");
            if (operation == "add")
            {
                //validated inside the if block because this parameter is only defined when the operation is defined as add
                if (newMessage != null)
                {
                    //index into list
                    //add to user message history
                    User user = ListOfUsers[elementIndex];
                    user.AddMessageToHistory(newMessage);

                    // update user in DB
                    context.Users.Update(user);
                    context.SaveChanges();
                }
                else
                    throw new ArgumentException("message is invalid; either null or undefined");
            }
            else
            {
                //validated inside the else block because this parameter is only defined when the operation is defined as remove
                if (messageID == -1)
                    throw new ArgumentException("messageID must be defined");
                else
                {
                    User user = ListOfUsers[elementIndex];
                    user.RemoveMessageFromHistory(messageID);

                    // update user in DB
                    context.Users.Update(user);
                    context.SaveChanges();
                }

            }
        }

        public void ModifyUserReplyHistory(string userName, string operation, Reply newReply = null, int replyID = -1)
        {
            //GENERAL INFO:
            //username and operation must be defined ALWAYS
            //set newReply to null if removing and to a valid object if adding
            //replyID is set to -1 by default if the operation is not remove

            //validation of non-operation specific parameters
            int elementIndex = this.FindUserIndex(userName);
            if (elementIndex == -1)
                throw new ArgumentException("Username is not valid or does not exist in the UserList collection");
            if (!(operation == "add" || operation == "remove"))
                throw new ArgumentException("Enter a valid operation; either string 'add' or string 'remove'");
            if (operation == "add")
            {
                //validate inside the if block because this parameter is only defined when the operation is add
                if (newReply != null)
                {
                    //index into list
                    //add to user reply history
                    User user = ListOfUsers[elementIndex];
                    user.AddToReplyHistory(newReply);

                    // update user in DB
                    context.Users.Update(user);
                    context.SaveChanges();
                }
                else
                    throw new ArgumentException("message is invalid; either null or undefined");
            }
            else
            {
                //validated inside the else block because this parameter is only defined when the operation is defined as remove
                if (replyID == -1)
                    throw new ArgumentException("messageID must be defined");
                else
                {
                    User user = ListOfUsers[elementIndex];
                    user.RemoveReplyFromHistory(replyID);

                    // update user in DB
                    context.Users.Update(user);
                    context.SaveChanges();
                }

            }
        }

        public void FindAndReplaceUser(string userName, User newUser)
        {
            User user = ListOfUsers[FindUserIndex(userName)];

            // remove old user, add new one
            context.Users.Remove(user);
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void AddNewUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void RemoveUser(string userName)
        {
            foreach (User user in ListOfUsers)
            {
                if (user.Username == userName)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    break;
                }
            }
        }

        private int FindUserIndex(string userName)
        {
            //returns index in list where the user exists
            for (int i = 0; i < ListOfUsers.Count; i++)
            {
                if (ListOfUsers[i].Username == userName)
                    return i;
            }
            //returns -1 if not found
            return -1;
        }
    }
}
