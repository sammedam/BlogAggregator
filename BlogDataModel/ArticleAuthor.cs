using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDataModel
{
    public class ArticleAuthor
    {
        public int AuthorID { get; set; }
        public int PostID { get; set; }
        public Post Posts { get; set; }
        public Author Authors { get; set; }
    }
}
