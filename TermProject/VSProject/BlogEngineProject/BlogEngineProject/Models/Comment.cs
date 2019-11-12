using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngineProject.Models
{
    public class Comment
    {
        public int CommentInt { get; set; }
        public String Username { get; set; }
        public String CommentContent { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
