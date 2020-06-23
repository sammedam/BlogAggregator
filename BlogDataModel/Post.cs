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
        public int BlogID { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }

    }
}
