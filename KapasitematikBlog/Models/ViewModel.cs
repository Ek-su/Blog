using KapasitematikBlog.Domain;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KapasitematikBlog.Models
{
    public class ViewModel
    {
        public IEnumerable<KapasitematikBlog.Domain.Kategori> Kategoris { get; set; }
        public IEnumerable<KapasitematikBlog.Domain.Kategori> ListKategoris { get; set; }
        public IEnumerable<KapasitematikBlog.Domain.Makale> Articles { get; set; }       
        public IEnumerable<KapasitematikBlog.Domain.Makale> ListMakale { get; set; }  
        public KapasitematikBlog.Domain.Makale Makale { get; set; }

        public PagedList<Makale> makale { get; set; }
        public PagedList<Makale> MyArticle { get; set; }
        public PagedList<Makale> OneArticle { get; set; }
        public PagedList<Makale> TwoArticle { get; set; }
        public PagedList<Makale> ArticleSkipTwo { get; set; }

       

    }
}
