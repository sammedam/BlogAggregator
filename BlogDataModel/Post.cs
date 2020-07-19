using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDataModel
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        [Required]
        [StringLength(60)]
        public string PostTitle { get; set; }
        public DateTime PostDateCreated { get; set; }
        public int PostNumComments { get; set; }
        [StringLength(3000)]
        public string Content { get; set; }

        [StringLength(1000)]
        public string Summary { get; set; }

        public string absURI { get; set; }

        public string PCID { get; set; } 

        public DateTime Lastupdated { get; set; }
        public int BlogID { get; set; }
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
        public virtual ICollection<ArticleAuthor> ArticleAuthors { get; set; }
    }
}
