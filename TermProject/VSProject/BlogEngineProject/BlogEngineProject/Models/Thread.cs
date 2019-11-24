using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngineProject.Models
{
    public class Thread
    {
        // private fields
        private List<Post> posts = new List<Post>();
        // auto implemented properties
        public int ThreadID { get; set; }
        public String Name { get; set; }
        public String CreatorName { get; set; }
        public String Bio { get; set; }
        public String Category { get; set; }
        public String ProfilePicURL { get; set; }
        public List<Post> Posts
        {
            get
            {
                return posts;
            }
        }

        // METHODS
        public void AddPostToThread(Post post) => Posts.Add(post);

        public Post RemovePostFromHistory(int postID)
        {
            // find post
            // then remove it
            Post removedPost = null;
            foreach (Post p in Posts)
            {
                if (p.PostID == postID)
                {
                    removedPost = p;
                    Posts.Remove(p);
                    return removedPost;
                }
            }
            return removedPost;
        }
    }
}
