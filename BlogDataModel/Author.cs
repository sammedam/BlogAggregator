using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDataModel
{
    public class Author
    {
        [Required]
        [StringLength(50)]
        public string AuthorName { get; set; }
        [StringLength(30)]
        public string AuthorCity { get; set; }
        [StringLength(30)]
        public string AuthorState { get; set; }
        [StringLength(30)]
        public string AuthorCountry { get; set; }
        [Key]
        public int AuthorID { get; set; }

    }
}
