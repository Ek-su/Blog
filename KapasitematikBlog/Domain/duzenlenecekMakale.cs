using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KapasitematikBlog.Domain
{
    public class duzenlenecekMakale
    {
        public int MakaleId { get; set; }
        public string MakaleBaslik { get; set; }
        public string MakaleAciklama { get; set; }
        public int? MakaleKategoriId { get; set; }
        public IFormFile ResimUrl { get; set; }
    }
}
