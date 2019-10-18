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

        /* this series of methods will modify the reply history of a MESSAGE */
        /*public static void AddReplyToMessage(string userName, int messageID, Reply newReply)
        {
            //find user in userlist
            //set reply in message reply list
            int userIndex = UserList.FindUserIndex(userName);
            UserList.listOfUsers[userIndex].AddReplyToMessage(messageID, newReply);
        }

        public static void RemoveReplyFromMessage(string userName, int messageID, int replyID)
        {
            //find user in userlist
            //remove reply from message reply list
            int userIndex = UserList.FindUserIndex(userName);
            UserList.listOfUsers[userIndex].RemoveReplyFromMessage(messageID, replyID);
        }*/

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

        /*
        public static void FindAndReplaceUserMessage(string userName, int messageID, Message newMessage)
        {
            //GENERAL INFO:
            //takes in a username and a neweMessage object
            //finds the old user via the username parameter
            //the found user will then have the message connected to the messageID replaced with the newMessage

            //ensures that target username and username of the newUser object are the same
            if (userName == newMessage.UserNameSignature)
            {
                int userIndex = FindUser(userName);
                User userInQuestion = listOfUsers[userIndex];
                List<Message> userMessageHistory = userInQuestion.GetMessageList;
                for (int i = 0; i < userMessageHistory.Count(); i++)
                {
                    if (messageID == userMessageHistory[i].MessageID)
                    {
                        //easy way to switch out the old message for the new one
                        Message tempReply = userMessageHistory[i];
                        ListOfUsers[userIndex].RemoveMessageFromHistory(messageID);
                        ListOfUsers[userIndex].AddMessageToHistory(newMessage);
                    }
                }
            }
            else
                throw new ArgumentException("please pass in a newMessage and userName string that have equivalent user name values");
        }*/
        /*
        public static void AddToUserReplyHistory(string userName, Reply newReply)
        {
            //GENERAL INFO:
            //takes in a username and a newUser object
            //finds the replier via the username parameter
            //the found user will then have the newReply added to their history

            //ensures that target username and username of the newReply object are the same
            if (userName == newReply.UserNameSignature)
            {
                int userIndex = FindUser(userName);
                listOfUsers[userIndex].AddToReplyHistory(newReply);
            }
            else
                throw new ArgumentException("please pass in a newReply and userName string that have equivalent user name values");
        }

        public static Reply RemoveReplyFromUserHistory(string userName, int replyID)
        {
            //GENERAL INFO:
            //takes in a username and a newUser object
            //finds the replier via the username parameter
            //the found user will then have the newReply added to their history

            int userIndex = FindUser(userName);
            User userInQuestion = listOfUsers[userIndex];
            List<Reply> userReplyHistory = userInQuestion.GetReplyHistory;
            //ensures that target username and username of the newReply object are the same
            for (int i =0; i < userReplyHistory.Count(); i++)
            {
                if (replyID == userReplyHistory[i].ReplyID)
                {
                    Reply tempReply = userReplyHistory[i];
                    ListOfUsers[userIndex].RemoveReplyFromHistory(replyID);
                    return tempReply;
                }
            }
            return null;
        }*/

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
