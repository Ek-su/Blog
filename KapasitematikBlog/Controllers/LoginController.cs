using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KapasitematikBlog.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KapasitematikBlog.Controllers
{
    public class LoginController : Controller
    {
        KapasitematikBlogDbContext db = new KapasitematikBlogDbContext();
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(Admin p)
        {
            KapasitematikBlogDbContext db = new KapasitematikBlogDbContext();
            var adminuserinfo = db.Admin.FirstOrDefault(x => x.AdminAd == p.AdminAd &&
                x.AdminSifre == p.AdminSifre);
            //var adminuserinfo = db.Admin.Where(x => x.AdminAd == p.AdminAd && x.AdminSifre == p.AdminSifre).FirstOrDefault();
            if (adminuserinfo != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.AdminAd)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                 HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Category");
                //return RedirectToAction("Index", "Category");
            }
            return View();
            //else
            //{
            //    return RedirectToAction("Index","Category");
            //}         
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");

        }
    }
}