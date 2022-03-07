using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KapasitematikBlog.Domain
{
    public partial class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }
        public string KullaniciAd { get; set; }
        public string KullaniciSoyad { get; set; }
        public string KullaniciName { get; set; }
        public string KullaniciPassword { get; set; }
    }
}
