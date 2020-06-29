using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDataModel
{
    public class CommentatorComment { 
        public int CommentatorID { get; set; }
        public int CommentID { get; set; }
        public Comments comments { get; set; }
        public Commentator Commentators { get; set; }
    }
}

