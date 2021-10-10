using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCDemo.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        private CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var values = categoryManager.GetAll();
            return View(values);
        }
    }
}
