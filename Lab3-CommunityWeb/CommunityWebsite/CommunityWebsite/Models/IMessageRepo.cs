using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public interface IMessageRepo
    {
        List<Message> GetMessageList(string chatRoomName);
        int GetNumberOfChats { get; }
        String[] GetChatNameArray { get; }
        void SortMessagesByDate(string chatRoom);
        void addMessageToBoard(string chatRoomName, Message message);
        void removeMessageFromBaord(string chatRoomName, int messageID);
        Message getMessageFromBoard(string chatRoomName, int messageID);
        bool findAndAddToMessageReplies(string chatRoomName, int parentMessageID, Reply newReply);
    }
}
