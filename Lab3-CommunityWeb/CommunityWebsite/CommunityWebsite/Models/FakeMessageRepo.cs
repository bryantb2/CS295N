using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public static class FakeMessageRepo
    {
        //CLASS FIELDS
        private static String[] chatGenres = new String[] { "General Chat", "Star Wars Chat" };
        private static List<Message> generalChat = new List<Message>();
        private static List<Message> starWarsChat = new List<Message>();

        //PROPERTIES
        public static List<Message> GetMessageList(string chatRoomName)
        {
            if (chatRoomName == "general")
            {
                return FakeMessageRepo.generalChat;
            }
            else if(chatRoomName == "starwars")
            {
                return FakeMessageRepo.starWarsChat;
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
        public static void SortMessagesByDate(string chatRoom)
        {
            if(chatRoom == "general")
            {
                generalChat.Sort((message1, message2) => message2.UnixTimeStamp.CompareTo(message1.UnixTimeStamp));
            }
            else if (chatRoom == "starwars")
            {
                starWarsChat.Sort((message1, message2) => message2.UnixTimeStamp.CompareTo(message1.UnixTimeStamp));
            }
            
        }

        public static void addMessageToBoard(string chatRoomName, Message message)
        {
            if (chatRoomName == "general")
            {
                FakeMessageRepo.generalChat.Add(message);
            }
            else if (chatRoomName == "starwars")
            {
                FakeMessageRepo.starWarsChat.Add(message);
            }
            else
                throw new ArgumentException("Chat room argument must be either string 'starwars'" +
                    "or string 'general'");
        }


        public static void removeMessageFromBaord(string chatRoomName, int messageID)
        {
            if (chatRoomName == "general")
            {
                foreach (Message message in FakeMessageRepo.generalChat)
                {
                    if(message.MessageID == messageID)
                    {
                        FakeMessageRepo.generalChat.Remove(message);
                    }
                }
            }
            else if (chatRoomName == "starwars")
            {
                foreach (Message message in FakeMessageRepo.starWarsChat)
                {
                    if (message.MessageID == messageID)
                    {
                        FakeMessageRepo.starWarsChat.Remove(message);
                    }
                }
            }
            else
                throw new ArgumentException("Chat room argument must be either string 'starwars'" +
                    "or string 'general'");
        }


        public static Message getMessageFromBoard(string chatRoomName, int messageID)
        {
            if(chatRoomName == "general")
            {
                //returns a null if the message does not exist
                foreach (Message m in generalChat)
                {
                    if(m.MessageID == messageID)
                    {
                        return m;
                    }
                }
            }
            else if(chatRoomName == "starwars")
            {
                //returns a null if the message does not exist
                foreach (Message m in starWarsChat)
                {
                    if (m.MessageID == messageID)
                    {
                        return m;
                    }
                }
                return null;
            }
            //means that the chatroom name is invalid
            return null;
        }


        public static bool findAndAddToMessageReplies(string chatRoomName, int parentMessageID, Reply newReply)
        {
            if (chatRoomName == "general")
            {
                //finds and replaces the message if found
                for (int i = 0; i < generalChat.Count(); i++)
                {
                    if (parentMessageID == generalChat[i].MessageID)
                    {
                        generalChat[i].AddToReplyHistory(newReply);
                        return true;
                    }
                }
            }
            else if (chatRoomName == "starwars")
            {
                //finds and replaces the message if found
                for (int i = 0; i < starWarsChat.Count(); i++)
                {
                    if (parentMessageID == starWarsChat[i].MessageID)
                    {
                        starWarsChat[i].AddToReplyHistory(newReply);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
