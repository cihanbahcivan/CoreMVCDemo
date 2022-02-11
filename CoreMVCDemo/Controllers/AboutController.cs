using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace CoreMVCDemo.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutManager _aboutManager = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var values = _aboutManager.GetAll();
            return View(values);
        }

        public PartialViewResult SocialMediaAbout()
        {

            return PartialView();
        }
    }
}
