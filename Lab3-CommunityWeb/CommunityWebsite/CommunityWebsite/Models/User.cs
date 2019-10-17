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
        private List<Reply> replyHistory;
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

        public void AddMessageToHistory(Message message)
        {
            if(message.UserNameSignature == this.userName)
            {
                this.messageHistory.Add(message);
            }
        }

        public void RemoveMessageFromHistory(int messageSignature, string writterUserName)
        {
            foreach (Message message in this.messageHistory)
            {
                if (message.MessageID == messageSignature && message.UserNameSignature == writterUserName)
                {
                    this.messageHistory.Remove(message);
                }
            }
        }
    }
}
