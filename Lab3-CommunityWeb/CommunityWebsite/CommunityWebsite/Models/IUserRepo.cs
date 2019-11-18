﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public interface IUserRepo
    {
        IQueryable<User> ListOfUsers { get; }
        int NumberOfUsers { get; }
        void ModifyUserMessageHistory(string userName, string operation, Message newMessage = null, int messageID = -1);
        void ModifyUserReplyHistory(string userName, string operation, Reply newReply = null, int replyID = -1);
        void AddNewUser(User user);
        void RemoveUser(string userName);
    }
}
