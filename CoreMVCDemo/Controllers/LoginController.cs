using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace CoreMVCDemo.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
        {
            Context c = new Context();
            var dataValue = c.Writers.FirstOrDefault(x =>
                x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);

            if (dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, writer.WriterMail)
                };
                var userIdentity = new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principle = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principle);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }

        }

        //using var context = new Context();
        //var dataValue = context.Writers.FirstOrDefault(x =>
        //    x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        //if (dataValue != null)
        //{
        //    HttpContext.Session.SetString("userName",writer.WriterMail);
        //    return RedirectToAction("Index", "Writer");
        //}
        //else
        //{
        //    return View();
        //}
    }
}
