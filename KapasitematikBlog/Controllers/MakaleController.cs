using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KapasitematikBlog.Domain;
using KapasitematikBlog.Models;
using KapasitematikBlog.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KapasitematikBlog.Controllers
{

    public class MakaleController : Controller
    {

        MakaleRepository makaleRepository = new MakaleRepository();
        KapasitematikBlogDbContext db = new KapasitematikBlogDbContext();
        public IActionResult Index()
        {
            var makaleler = db.Makale.ToList();
            return View(makaleler);
        }
        [HttpGet]
        public IActionResult AddMakale()
        {
            List<SelectListItem> values = (from x in db.Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddMakale(makaleekle p)
        {
            Makale m = new Makale();
            if(p.ResimUrl != null)
            {
                var extension = Path.GetExtension(p.ResimUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images/",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ResimUrl.CopyTo(stream);
                m.ResimUrl = newimagename;
            }
            m.MakaleBaslik = p.MakaleBaslik;
            m.MakaleAciklama = p.MakaleAciklama;
            m.MakaleKategoriId = p.MakaleKategoriId;           
            makaleRepository.TAdd(m);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteMakale(int id)
        {
            makaleRepository.TDelete(new Makale { MakaleId = id });
            return RedirectToAction("Index");
        }
        public IActionResult MakaleGet(int id)
        {
            var x = makaleRepository.TGet(id);
            List<SelectListItem> values = (from y in db.Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.KategoriAd,
                                               Value = y.KategoriId.ToString()
                                           }).ToList();
                                           

            Makale m = new Makale()
            {
                MakaleId = x.MakaleId,                
                MakaleBaslik = x.MakaleBaslik,
                MakaleAciklama = x.MakaleAciklama,
                MakaleKategoriId = x.MakaleKategoriId,
                ResimUrl = x.ResimUrl
            };
            return View(m);
        }
        [HttpPost]
        public IActionResult MakaleUpdate(Makale p)
        {
            var x = makaleRepository.TGet(p.MakaleId);
            x.MakaleBaslik = p.MakaleBaslik;
            x.MakaleAciklama = p.MakaleAciklama;
            x.MakaleKategoriId = p.MakaleKategoriId;
            x.ResimUrl = p.ResimUrl;
            makaleRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}