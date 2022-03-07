using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KapasitematikBlog.Domain
{
    public partial class Kategori
    {
        public Kategori()
        {
            Makale = new HashSet<Makale>();
        }

        public int KategoriId { get; set; }
        public string KategoriAd { get; set; }

        public ICollection<Makale> Makale { get; set; }

    }
}
