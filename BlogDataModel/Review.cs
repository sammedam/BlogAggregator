using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDataModel
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public int PostID { set; get; }
    }
}
