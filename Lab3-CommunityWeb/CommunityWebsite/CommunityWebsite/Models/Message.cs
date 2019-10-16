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
        private string topic;
        private Int32 unixTimeStamp;
        private int messageID; //unique message ID
        private string userNameSignature; //name of user who inputted the message
        private string messageTitle;

        //CONSTRUCTOR
        public Message(string contentHeader, string content, string nameOfUser, string topic)
        {
            this.messageContent = content;
            //increments and set message ID
            this.messageID = GetNewMessageID();
            this.userNameSignature = nameOfUser;
            this.topic = topic;
            this.messageTitle = contentHeader;
            this.unixTimeStamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds; ;
        }

        //STATIC METHODS FOR IDs
        public int GetNewMessageID()
        {
            Message.messageNumber += 1;
            return Message.messageNumber;
        }

        //PROPERTIES
        public Int32 UnixTimeStamp
        {
            get { return unixTimeStamp; }
            set { this.unixTimeStamp = value; }
        }
        public string MessageContent
        {
            get { return this.messageContent; }
            set { this.messageContent = value; }
        }

        public DateTimeOffset GetTimePosted
        {
            //credit goes to: https://stackoverflow.com/questions/249760/how-can-i-convert-a-unix-timestamp-to-datetime-and-vice-versa
            get
            {
                DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                long unixTimeStampInTicks = (long)(this.unixTimeStamp * TimeSpan.TicksPerSecond);
                return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
            }
        }

        public string MessageTitle
        {
            get { return this.messageTitle; }
            set { this.messageTitle = value; }
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
