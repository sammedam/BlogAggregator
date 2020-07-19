using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Models
{
    public class Comments
    {
        public string CommentPosted { get; set; }
        public string Commenter { get; set; }
        public int PostID { get; set; }
        public DateTime DateCommentPosted { get; set; }
    }
}
