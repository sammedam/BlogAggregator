using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDataModel
{
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }
        public string CommentPosted { get; set; }
        public DateTime DateCommentPosted { get; set; }
        public int PostID { get; set;  }
        public int BlogID { get; set;  }

        public virtual ICollection<CommentatorComment> CommentatorsComments { get; set; }



    }
}
