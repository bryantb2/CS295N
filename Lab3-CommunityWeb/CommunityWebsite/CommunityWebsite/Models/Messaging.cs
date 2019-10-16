using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public static class MessageBoard
    {
        //CLASS FIELDS
        private static List<Message> generalChat = new List<Message>();
        private static List<Message> starWarsChat = new List<Message>();
        

        //PROPERTIES
        public static List<Message> GetMessageList(string chatRoomName)
        {
            if (chatRoomName == "general")
            {
                return MessageBoard.generalChat;
            }
            else
            {
                return MessageBoard.starWarsChat;
            }
        }

        //METHODS
        public static void addMessageToBoard(string chatRoomName, Message message)
        {
            if (chatRoomName == "general")
            {
                MessageBoard.generalChat.Add(message);
            }
            else if (chatRoomName == "starwars")
            {
                MessageBoard.starWarsChat.Add(message);
            }
            else
                throw new ArgumentException("Chat room argument must be either string 'starwars'" +
                    "or string 'general'");
        }

        public static void removeMessageFromBaord(string chatRoomName, int messageSignature, string writterUserName)
        {
            if (chatRoomName == "general")
            {
                foreach (Message message in MessageBoard.generalChat)
                {
                    if(message.DigitalSignature == messageSignature && message.UserNameSignature == writterUserName)
                    {
                        MessageBoard.generalChat.Remove(message);
                    }
                }
            }
            else if (chatRoomName == "starwars")
            {
                foreach (Message message in MessageBoard.starWarsChat)
                {
                    if (message.DigitalSignature == messageSignature && message.UserNameSignature == writterUserName)
                    {
                        MessageBoard.starWarsChat.Remove(message);
                    }
                }
            }
            else
                throw new ArgumentException("Chat room argument must be either string 'starwars'" +
                    "or string 'general'");
        }
    }
}
