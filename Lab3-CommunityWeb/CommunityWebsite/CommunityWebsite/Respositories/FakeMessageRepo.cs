using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;

namespace CommunityWebsite.Respositories
{
    public class FakeMessageRepo : IMessageRepo
    {
        // CLASS FIELDS
        private String[] chatGenres = new String[] { "General Chat", "Star Wars Chat" };
        private List<Message> generalChat = new List<Message>();
        private List<Message> starWarsChat = new List<Message>();

        // PROPERTIES 
        public bool HasFillBeenUsed { get; set; }

        public List<Message> Messages { get { return generalChat; } }

        public List<Message> SWMesssages {
            get
            {
                // get messages and then add the SW ones to the return list
                List<Message> starWarsMessageList = new List<Message>();
                foreach(Message m in Messages)
                {
                    if (m.Topic == "starwars")
                        starWarsMessageList.Add(m);
                }

                return starWarsMessageList;
            }
        }

        public List<Message> GeneralMesssages
        {
            get
            {
                // get messages and then add the general ones to the return list
                List<Message> generalMessageList = new List<Message>();
                foreach (Message m in Messages)
                {
                    if (m.Topic == "general")
                        generalMessageList.Add(m);
                }

                return generalMessageList;
            }
        }

        public int NumberOfChats { get { return chatGenres.Length; } }
        
        public String[] ChatNameArray { get { return chatGenres; } }

        public List<Message> SortMessagesByDate(string chatRoom)
        {
            if(chatRoom == "general")
            {
                generalChat.Sort((message1, message2) => message2.UnixTimeStamp.CompareTo(message1.UnixTimeStamp));
            }
            else if (chatRoom == "starwars")
            {
                starWarsChat.Sort((message1, message2) => message2.UnixTimeStamp.CompareTo(message1.UnixTimeStamp));
            }

            return null;
            
        }

        public void addMessageToBoard(string chatRoomName, Message message)
        {
            if (chatRoomName == "general")
            {
                 generalChat.Add(message);
            }
            else if (chatRoomName == "starwars")
            {
                 starWarsChat.Add(message);
            }
            else
                throw new ArgumentException("Chat room argument must be either string 'starwars'" +
                    "or string 'general'");
        }


        public void removeMessageFromBaord(string chatRoomName, int messageID)
        {
            if (chatRoomName == "general")
            {
                foreach (Message message in  generalChat)
                {
                    if(message.MessageID == messageID)
                    {
                         generalChat.Remove(message);
                    }
                }
            }
            else if (chatRoomName == "starwars")
            {
                foreach (Message message in  starWarsChat)
                {
                    if (message.MessageID == messageID)
                    {
                         starWarsChat.Remove(message);
                    }
                }
            }
            else
                throw new ArgumentException("Chat room argument must be either string 'starwars'" +
                    "or string 'general'");
        }


        public Message getMessageFromBoard(string chatRoomName, int messageID)
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


        public bool findAndAddToMessageReplies(string chatRoomName, int parentMessageID, Reply newReply)
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
