using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KapasitematikBlog.Domain;
using KapasitematikBlog.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KapasitematikBlog.Controllers
{
    
    public class CategoryController : Controller
    {
        KategoriRepository kategoriRepository = new KategoriRepository();
        [Authorize]
        public IActionResult Index()
        {           
            return View(kategoriRepository.TList());
        }
        [HttpGet]
        public IActionResult KategoriAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KategoriAdd(Kategori p)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriAdd");
            }
            kategoriRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult KategoriGet(int id)
        {
            var x = kategoriRepository.TGet(id);
            Kategori ct = new Kategori()
            {
                KategoriAd = x.KategoriAd,
                KategoriId = x.KategoriId
            };
            return View(ct);
        }
        [HttpPost]
        public IActionResult KategoriUpdate(Kategori p)
        {
            var x = kategoriRepository.TGet(p.KategoriId);
            x.KategoriAd = p.KategoriAd;
            kategoriRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
        public IActionResult KategoriDelete(int id)
        {
            
            //db.Kategori.Remove(silinecekKategori);
            //db.SaveChanges();
            var x = kategoriRepository.TGet(id);
            kategoriRepository.TDelete(x);
            return RedirectToAction("Index");
        }
    }
}
