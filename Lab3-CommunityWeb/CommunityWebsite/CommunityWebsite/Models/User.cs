using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class User
    {
        //CLASS FIELDS
        private string userName;
        private List<Message> messageHistory = new List<Message>();
        private List<Reply> replyHistory = new List<Reply>();
        private string password;

        //CONSTRUCTOR
        public User(string userName)
        {
            this.userName = userName;
        }

        //PROPERTIES
        public List<Reply> GetReplyHistory
        {
            get { return this.replyHistory; }
        }
        
        public List<Message> GetMessageList
        {
            get { return this.messageHistory; }
        }

        public string Username
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public string Password
        {
            set { this.password = value; }
            get { return this.password; }
        }

        //METHODS
        public void AddToReplyHistory(Reply reply)
        {
            this.replyHistory.Add(reply);
        }

        public void RemoveReplyFromHistory(int repyID)
        {
            foreach (Reply reply in this.replyHistory)
            {
                if (reply.ReplyID == repyID)
                {
                    this.replyHistory.Remove(reply);
                }
            }
        }

        public void AddMessageToHistory(Message message)
        {
            if(message.UserNameSignature == this.userName)
            {
                this.messageHistory.Add(message);
            }
        }

        public void RemoveMessageFromHistory(int messageID)
        {
            foreach (Message message in this.messageHistory)
            {
                if (message.MessageID == messageID)
                {
                    this.messageHistory.Remove(message);
                }
            }
        }

        public void AddReplyToMessage(int messageID, Reply externalReply)
        {
            //this methods syncs another person's response to the message itself
            foreach(Message m in messageHistory)
            {
                if(m.MessageID == messageID)
                {
                    m.AddToReplyHistory(externalReply);
                }
            }
        }

        public void RemoveReplyFromMessage(int messageID, int replyID)
        {
            foreach (Message m in messageHistory)
            {
                if (m.MessageID == messageID)
                {
                    List<Reply> replyHistory = m.GetReplyHistory;
                    for(int i = 0; i < replyHistory.Count();i++)
                    {
                        if(replyHistory[i].ReplyID == replyID)
                        {
                            m.RemoveReplyHistory(replyID);
                        }
                    }
                }
            }
        }
    }
}
