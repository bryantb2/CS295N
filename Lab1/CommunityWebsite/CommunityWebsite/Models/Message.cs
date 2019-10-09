using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class Message
    {
        //CLASS FIELDS
        private string messageContent;
        private int digitalSignature; //unique message ID
        private string userNameSignature; //name of user who inputted the message

        //CONSTRUCTOR
        public Message(string content, int signature, string nameOfUser)
        {
            this.messageContent = content;
            this.digitalSignature = signature;
            this.userNameSignature = nameOfUser;
        }

        //PROPERTIES
        public string MessageContent
        {
            get { return this.messageContent; }
            set { this.messageContent = value; }
        }
        
        public int DigitalSignature
        {
            get { return this.digitalSignature; }
            set { this.digitalSignature = value; }
        }

        public string UserNameSignature
        {
            get { return this.userNameSignature; }
            set { this.userNameSignature = value; }
        }
    }
}
