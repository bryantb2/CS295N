using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngineProject.Models
{
    public class User
    {
        // auto implemented properties
        public int UserID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Gender { get; set; }
        public DateTime DateJoined { get; set; }
        public Thread OwnedThread { get; set; }
        public List<int> FavoriteThreads { get; set; } // will store a list of thread DB ID numbers
        public List<Comment> CommentHistory { get; set; }

        // METHODS
        public void AddToFavorites(int threadID) => FavoriteThreads.Add(threadID);

        public int RemoveFromFavorites(int threadID)
        {
            // find threadID
            // then remove it
            int removedThreadID = -1;
            foreach (int thread in FavoriteThreads)
            {
                if (thread == threadID)
                {
                    removedThreadID = thread;
                    FavoriteThreads.Remove(thread);
                }
            }
            return removedThreadID;
        }

        public void AddCommentToHistory(Comment comment) => CommentHistory.Add(comment);

        public Comment RemoveCommentFromHistory(int commentID)
        {
            // find comment
            // then remove it
            Comment removedComment = null;
            foreach (Comment c in CommentHistory)
            {
                if (c.CommentID == commentID)
                {
                    removedComment = c;
                    CommentHistory.Remove(c);
                }
            }
            return removedComment;
        }


    }
}
