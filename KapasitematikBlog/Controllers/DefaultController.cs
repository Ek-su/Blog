using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace KapasitematikBlog.Controllers
{

    public class DefaultController : Controller
    {
     
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KategoriDetay()
        {           
            return View();
        }
    }
}