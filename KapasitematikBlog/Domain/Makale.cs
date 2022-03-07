using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KapasitematikBlog.Domain
{
    public partial class Makale
    {
        public int MakaleId { get; set; }
        public string MakaleBaslik { get; set; }
        public string MakaleAciklama { get; set; }
        public int? MakaleKategoriId { get; set; }
        public string ResimUrl { get; set; }

        public Kategori MakaleKategori { get; set; }

    }
}
