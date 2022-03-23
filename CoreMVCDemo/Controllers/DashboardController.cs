using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;

namespace CoreMVCDemo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            using(Context context = new Context())
            {
                ViewBag.v1 = context.Blogs.Count().ToString();
                ViewBag.v2 = context.Blogs.Where(x => x.WriterId == 1).Count().ToString();
                ViewBag.v3 = context.Categories.Count().ToString();
            }

            return View();
        }
    }
}
