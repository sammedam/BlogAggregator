using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace BlogDataModel
{
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }
        [Required]
        [StringLength(1000)]
        public string CommentPosted { get; set; }
        public DateTime DateCommentPosted { get; set; }
        public int PostID { get; set;  }
        public int BlogID { get; set;  }

        public string Absuri { get; set; }

        public string PCID { get; set; }

        public virtual ICollection<CommentatorComment> CommentatorsComments { get; set; }



    }
}
