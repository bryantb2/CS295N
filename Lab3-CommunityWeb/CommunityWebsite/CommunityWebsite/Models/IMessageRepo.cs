using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public interface IMessageRepo
    {
        int NumberOfChats { get; }
        String[] ChatNameArray { get; }
        List<Message> GeneralMessages { get; }
        List<Message> SWMessages { get; }
        void addMessageToBoard(string chatRoomName, Message message);
        void removeMessageFromBaord(string chatRoomName, int messageID);
        Message getMessageFromBoard(string chatRoomName, int messageID);
        bool findAndAddToMessageReplies(string chatRoomName, int parentMessageID, Reply newReply);
        void SortMessagesByDate(string chatRoom);

        // delete this later
        void FillRepoWithMessages();
    }
}
