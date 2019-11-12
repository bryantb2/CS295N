using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngineProject.Models
{
    public class Thread
    {
        // auto implemented properties
        public int ThreadID { get; set; }
        public String Name { get; set; }
        public String Bio { get; set; }
        public String Category { get; set; }
        public List<Post> Posts { get; set; }
        public String ProfilePicURL { get; set; }

        // METHODS
        public void AddPostToThread(Post post) => Posts.Add(post);

        public Post RemoveCommentFromHistory(int postID)
        {
            // find comment
            // then remove it
            Post removedPost = null;
            foreach (Post p in Posts)
            {
                if (p.PostID == postID)
                {
                    removedPost = p;
                    Posts.Remove(p);
                }
            }
            return removedPost;
        }
    }
}
