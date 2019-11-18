using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public interface IMessageRepo
    {
        int GetNumberOfChats { get; }
        String[] GetChatNameArray { get; }
        IQueryable<Message> GetGeneralMessages { get; }
        IQueryable<Message> GetSWMessages { get; }
        void addMessageToBoard(string chatRoomName, Message message);
        void removeMessageFromBaord(string chatRoomName, int messageID);
        Message getMessageFromBoard(string chatRoomName, int messageID);
        bool findAndAddToMessageReplies(string chatRoomName, int parentMessageID, Reply newReply);
        void SortMessagesByDate(string chatRoom);
    }
}
