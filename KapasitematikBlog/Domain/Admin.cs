using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KapasitematikBlog.Domain
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(20)]
        public string AdminAd { get; set; }
        [StringLength(20)]
        public string AdminSifre { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}
