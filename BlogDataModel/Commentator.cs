using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDataModel
{
    public class Commentator
    {
        [Key]
        public int CommentatorID { get; set; }
        public string CommentatorName { get; set; }
        public virtual ICollection<CommentatorComment> CommentatorComments { get; set; }


    }
}
