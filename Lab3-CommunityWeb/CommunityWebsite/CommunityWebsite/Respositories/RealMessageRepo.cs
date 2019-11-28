using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebsite.Respositories
{
    public class RealMessageRepo : IMessageRepo
    {
        // CLASS FIELDS
        private AppDbContext context;

        // CONSTRUCTOR
        public RealMessageRepo(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        // CLASS FIELDS
        private String[] chatGenres = new String[] { "General Chat", "Star Wars Chat" };

        // PROPERTIES 
        public List<Message> Messages { get { return context.Messages.Include("Replies").ToList(); } }

        public List<Message> SWMesssages
        {
            get
            {
                // get messages and then add the SW ones to the return list
                List<Message> starWarsMessageList = new List<Message>();
                foreach (Message m in Messages)
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
            List<Message> sortedMessages = null;
            if (chatRoom == "general")
            {
                var messages = GeneralMesssages;
                messages.Sort((message1, message2) => message2.UnixTimeStamp.CompareTo(message1.UnixTimeStamp));
                sortedMessages = messages;
            }
            else if (chatRoom == "starwars")
            {
                var messages = SWMesssages;
                messages.Sort((message1, message2) => message2.UnixTimeStamp.CompareTo(message1.UnixTimeStamp));
                sortedMessages = messages;
            }
            return sortedMessages;
        }

        public void addMessageToBoard(string chatRoomName, Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();  
        }


        public void removeMessageFromBaord(string chatRoomName, int messageID)
        {
            foreach (Message message in Messages)
            {
                if (message.MessageID == messageID)
                {
                    context.Messages.Remove(message);
                    context.SaveChanges();
                }
            }
        }


        public Message getMessageFromBoard(string chatRoomName, int messageID)
        {
            //returns a null if the message does not exist
            foreach (Message m in Messages)
            {
                if (m.MessageID == messageID)
                {
                    return m;
                }
            }
            //means that the chatroom name is invalid
            return null;
        }


        public bool findAndAddToMessageReplies(string chatRoomName, int parentMessageID, Reply newReply)
        {
            //finds and replaces the message if found
            for (int i = 0; i < Messages.Count(); i++)
            {
                if (parentMessageID == Messages[i].MessageID)
                {
                    // get message, add reply, then update in DB
                    Message message = Messages[i];
                    message.AddToReplyHistory(newReply);

                    context.Replies.Add(newReply);
                    context.Messages.Update(message);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
