using KapasitematikBlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KapasitematikBlog.ViewComponents
{
    public class CategoryGetList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            KategoriRepository kategoriRepository = new KategoriRepository();
            var kategorilist = kategoriRepository.TList();
            return View(kategorilist);
        }
    }
}
