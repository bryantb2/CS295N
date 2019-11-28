using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;

namespace CommunityWebsite.Respositories
{
    public interface IMessageRepo
    {
        int NumberOfChats { get; }
        String[] ChatNameArray { get; }
        List<Message> Messages { get; }
        List<Message> GeneralMesssages { get; }
        List<Message> SWMesssages { get; }
        void addMessageToBoard(string chatRoomName, Message message);
        void removeMessageFromBaord(string chatRoomName, int messageID);
        Message getMessageFromBoard(string chatRoomName, int messageID);
        bool findAndAddToMessageReplies(string chatRoomName, int parentMessageID, Reply newReply);
        List<Message> SortMessagesByDate(string chatRoom);
    }
}
