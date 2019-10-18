using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public static class UserList
    {
        //CLASS FIELDS
        private static List<User> listOfUsers = new List<User>();

        //PROPERTIES
        public static  List<User> ListOfUsers
        {
            get { return listOfUsers; }
        }

        public static int NumberOfUsers
        {
            get { return listOfUsers.Count; }
        }

        //METHODS

        /* this series of method will modify the message or reply history of a USER */
        public static void ModifyUserMessageHistory(string userName, string operation, Message newMessage=null, int messageID=-1)
        {
            //GENERAL INFO:
            //username and operation must be defined ALWAYS
            //set newMessage to null if removing and to a valid object if adding
            //messageID is set to -1 by default if the operation is not remove

            //validation of non-operation specific parameters
            int elementIndex = UserList.FindUserIndex(userName);
            if (elementIndex == -1)
                throw new ArgumentException("Username is not valid or does not exist in the UserList collection");
            if (!(operation == "add" || operation == "remove"))
                throw new ArgumentException("Enter a valid operation; either string 'add' or string 'remove'");
            if(operation=="add")
            {
                //validated inside the if block because this parameter is only defined when the operation is defined as add
                if (newMessage != null)
                {
                    //index into list
                    //add to user message history
                    listOfUsers[elementIndex].AddMessageToHistory(newMessage);
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
                    listOfUsers[elementIndex].RemoveMessageFromHistory(messageID);
            }
        }

        public static void ModifyUserReplyHistory(string userName, string operation, Reply newReply = null, int replyID = -1)
        {
            //GENERAL INFO:
            //username and operation must be defined ALWAYS
            //set newReply to null if removing and to a valid object if adding
            //replyID is set to -1 by default if the operation is not remove

            //validation of non-operation specific parameters
            int elementIndex = UserList.FindUserIndex(userName);
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
                    //add to user message history
                    listOfUsers[elementIndex].AddToReplyHistory(newReply);
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
                    listOfUsers[elementIndex].RemoveReplyFromHistory(replyID);
            }
        }

        public static void FindAndReplaceUser(string userName, User newUser)
        {
            //GENERAL INFO:
            //takes in a username and a newUser object
            //finds the old user via the username parameter
            //the found user will then be replaced with the newUSer
            
            int userIndex = FindUserIndex(userName);
            listOfUsers[userIndex] = newUser;
        }
        

        public static void AddNewUser(User user)
        {
            UserList.listOfUsers.Add(user);
        }

        public static void RemoveUser(string userName)
        {
            foreach (User user in listOfUsers)
            {
                if (user.Username == userName)
                {
                    UserList.listOfUsers.Remove(user);
                }
            }
        }

        private static int FindUserIndex(string userName)
        {
            //returns index in list where the user exists
            for (int i = 0; i < listOfUsers.Count; i++)
            {
                if (listOfUsers[i].Username == userName)
                    return i;
            }
            //returns -1 if not found
            return -1;
        }
    }
}
