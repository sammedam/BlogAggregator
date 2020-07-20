using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Models
{
    public class Article
    {
        public string ArticleTitle { get; set; }
        public string Summary { get; set; }
        public string ArticleURL { get; set; }
        public DateTime ArticleDateCreated { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
