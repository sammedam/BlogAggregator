using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDataModel
{
    public class ArticleCategory
    {
        public int PostID { get; set; }
        public int CategoryID { get; set; }
        public Post Posts { get; set; }
        public Category Categories { get; set; }
    }
}
