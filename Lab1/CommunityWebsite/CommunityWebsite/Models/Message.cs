using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class Message
    {
        //STATIC FIELDS
        private static int messageNumber = 0;

        //CLASS FIELDS (instance variables)
        private string messageContent;
        private int messageID; //unique message ID
        private string userNameSignature; //name of user who inputted the message

        //CONSTRUCTOR
        public Message(string content, string nameOfUser)
        {
            this.messageContent = content;
            //increments and set message ID
            this.messageID = GetNewMessageID();
            this.userNameSignature = nameOfUser;
        }

        //STATIC METHODS FOR IDs
        public int GetNewMessageID()
        {
            Message.messageNumber += 1;
            return Message.messageNumber;
        }

        //PROPERTIES
        public string MessageContent
        {
            get { return this.messageContent; }
            set { this.messageContent = value; }
        }
        
        public int DigitalSignature
        {
            get { return this.messageID; }
        }

        public string UserNameSignature
        {
            get { return this.userNameSignature; }
            set { this.userNameSignature = value; }
        }
    }
}
