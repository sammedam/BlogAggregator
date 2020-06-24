using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDataModel
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public string Label { set; get; }

        public virtual ICollection<ArticleCategory> ArticleCateories { get; set; }
    }
}
