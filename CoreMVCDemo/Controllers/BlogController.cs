using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreMVCDemo.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = _blogManager.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = _blogManager.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var values = _blogManager.Test(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> values = (from x in _categoryManager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();

            ViewBag.categoryValues = values;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);

            List<SelectListItem> values = (from x in _categoryManager.GetAll()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();

            ViewBag.categoryValues = values;

            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
                _blogManager.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogToDelete = _blogManager.GetById(id);
            _blogManager.Delete(blogToDelete);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blog = _blogManager.GetById(id);

            List<SelectListItem> values = (from x in _categoryManager.GetAll()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();
            ViewBag.categoryValues = values;
            return View(blog);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            blog.WriterId = 1;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            _blogManager.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }

    }
}
