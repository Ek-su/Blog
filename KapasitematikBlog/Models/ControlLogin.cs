using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KapasitematikBlog.Models
{
    public class ControlLogin : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                if (!string.IsNullOrEmpty(context.HttpContext.Session.GetString("KullaniciId")))
                {
                    base.OnActionExecuting(context);
                }
                else
                {
                    context.HttpContext.Response.Redirect("/login");
                }
            }
            catch (Exception)
            {
                context.HttpContext.Response.Redirect("/login");
            }
        }
    }
}
