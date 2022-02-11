using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace CoreMVCDemo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = _categoryManager.GetAll();
            return View(values);
        }
    }
}
