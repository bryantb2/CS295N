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
        private string password;

        //CONSTRUCTOR
        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        //PROPERTIES
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
            get { return this.password; }
        }

        //METHODS
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
                if (message.DigitalSignature == messageSignature && message.UserNameSignature == writterUserName)
                {
                    this.messageHistory.Remove(message);
                }
            }
        }
    }
}
