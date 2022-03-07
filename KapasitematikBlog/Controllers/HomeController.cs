using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KapasitematikBlog.Models;
using Microsoft.Extensions.Logging;
using KapasitematikBlog.Domain;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using KapasitematikBlog.Repositories;

namespace KapasitematikBlog.Controllers
{
    
    [AllowAnonymous]
    public class HomeController : Controller
    {
     KapasitematikBlogDbContext db;
        MakaleRepository makaleRepository = new MakaleRepository();
        public IActionResult Index()
        {
            var x = makaleRepository.TList();
            List<Makale> m = new List<Makale>();
            m.AddRange(x);
            
            return View(m);
        }
        public IActionResult Kategoriler()
        {
            KategoriRepository kategoriRepository = new KategoriRepository();
            var x = kategoriRepository.TList();
            List<Kategori> k = new List<Kategori>();
            k.AddRange(x);
            return View(k);
        }
        public IActionResult Hakkımızda()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult İletişim()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Makaleler()
        {
            return View();
        }
        public IActionResult HomePage()
        {
            return View();

        }
        public IActionResult Dokumanlar()
        {
            return View();
        }

        public IActionResult VerimlilikTakibi()
        {
            return View();
        }

        public IActionResult UretimTakibi()
        {
            return View();
        }
        public IActionResult MRPModülü()
        {
            return View();
        }
        public IActionResult ProgramTransfer()
        {
            return View();
        }
        public IActionResult TakımOmru()
        {
            return View();
        }
        public IActionResult GizlilikPolitikası()
        {
            return View();
        }
        public IActionResult ÇerezPolitikası()

   
     {
            return View();
        }
        public IActionResult VeriPolitikası()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }
}
