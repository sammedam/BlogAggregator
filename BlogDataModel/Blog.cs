using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDataModel
{
   public class Blog
    {
        [Required]
        [StringLength(50)]
        public string BlogName {get; set;}
        [Key]
        public int BlogID { get; set; }
        [Required]
        [StringLength(2000)]
        public string BlogURL { get; set; }
        public DateTime BlogDateAdded { get; set; }
        public int BlogPostsNum { get; set; }
        public DateTime BlogDateCreated { get; set; }
        public int AuthorID { get; set; }
    }
}
