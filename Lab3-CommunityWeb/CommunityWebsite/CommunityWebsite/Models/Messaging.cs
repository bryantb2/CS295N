using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public static class Messaging
    {
        //CLASS FIELDS
        private static String[] chatGenres = new String[] { "General Chat", "Star Wars Chat" };
        private static List<Message> generalChat = new List<Message>();
        private static List<Message> starWarsChat = new List<Message>();
        //this tracks the genre the user wants to load
        private static string selectedGenre = "";
        /*
         * this fangled BS exists because I want to the load the messageboard genre the user selected BUT
         * the topic string that the user select only exists in the redirect method I called to handle the form data.
         * It is super annoying to pass data from a redirect to an action method, so I opted to store it in the Message board (Messaging)
         * model.
         */


        //PROPERTIES
        public static string SelectedGenre
        {
            get { return selectedGenre; }
            set { selectedGenre = value; }
        }

        public static List<Message> GetMessageList(string chatRoomName)
        {
            if (chatRoomName == "general")
            {
                return Messaging.generalChat;
            }
            else if(chatRoomName == "starwars")
            {
                return Messaging.starWarsChat;
            }
            else
            {
                return null;
            }
        }

        public static int GetNumberOfChats
        {
            get { return chatGenres.Length; }
        }

        public static String[] GetChatNameArray
        {
            get { return chatGenres; }
        }

        //METHODS
        public static void addMessageToBoard(string chatRoomName, Message message)
        {
            if (chatRoomName == "general")
            {
                Messaging.generalChat.Add(message);
            }
            else if (chatRoomName == "starwars")
            {
                Messaging.starWarsChat.Add(message);
            }
            else
                throw new ArgumentException("Chat room argument must be either string 'starwars'" +
                    "or string 'general'");
        }

        public static void removeMessageFromBaord(string chatRoomName, int messageSignature, string writterUserName)
        {
            if (chatRoomName == "general")
            {
                foreach (Message message in Messaging.generalChat)
                {
                    if(message.DigitalSignature == messageSignature && message.UserNameSignature == writterUserName)
                    {
                        Messaging.generalChat.Remove(message);
                    }
                }
            }
            else if (chatRoomName == "starwars")
            {
                foreach (Message message in Messaging.starWarsChat)
                {
                    if (message.DigitalSignature == messageSignature && message.UserNameSignature == writterUserName)
                    {
                        Messaging.starWarsChat.Remove(message);
                    }
                }
            }
            else
                throw new ArgumentException("Chat room argument must be either string 'starwars'" +
                    "or string 'general'");
        }
    }
}
