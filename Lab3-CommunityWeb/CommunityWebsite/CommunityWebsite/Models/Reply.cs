﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class Reply
    {
        //STATIC FIELDS
        private static int replyNumber = 0;
        
        //CLASS FIELDS
        private string replyContent;
        private int replyID;
        private string userNameSignature;
        private Int32 unixTimeStamp;

        //CONSTRUCTOR
        public Reply(string replyContent, string userNameSignature)
        {
            this.replyContent = replyContent;
            this.userNameSignature = userNameSignature;
            this.unixTimeStamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            this.replyID = GetNewReplyID();
        }

        //PROPERTIES
        public int ReplyID
        {
            get { return this.replyID; }
        }

        public String ReplyContent
        {
            get { return this.replyContent; }
            set { this.replyContent = value; }
        }

        public String UserNameSignature
        {
            get { return this.userNameSignature; }
            set { this.userNameSignature = value; }
        }

        public Int32 UnixTimeStamp
        {
            get { return unixTimeStamp; }
            set { this.unixTimeStamp = value; }
        }

        public DateTime GetTimePosted
        {
            //credit goes to: https://stackoverflow.com/questions/249760/how-can-i-convert-a-unix-timestamp-to-datetime-and-vice-versa
            get
            {
                DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                long unixTimeStampInTicks = (long)(this.unixTimeStamp * TimeSpan.TicksPerSecond);
                return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
            }
        }

        //METHOD MANIPULATING STATIC MESSAGE ID INT
        private int GetNewReplyID()
        {
            //this should only get called within the class upon object instantiation
            if (replyNumber != 0)
            {
                Reply.replyNumber += 1;
            }
            return Reply.replyNumber;
        }
    }

    
}
