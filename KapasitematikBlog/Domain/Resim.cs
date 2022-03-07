using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KapasitematikBlog.Domain
{
    public partial class Resim
    {
        [Key]
        public int ResimId { get; set; }
        public string ResimUrl { get; set; }
       
    }
}
