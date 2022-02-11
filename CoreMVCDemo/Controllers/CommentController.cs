using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace CoreMVCDemo.Controllers
{
    public class CommentController : Controller
    {
        private CommentManager commentManager = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]

        public PartialViewResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogId = 2;

            commentManager.Add(p);
            return PartialView();
        }


        public PartialViewResult CommentListByBlog(int id)
        {
            var values= commentManager.GetAllByBlogId(id);
            return PartialView(values);
        }
    }
}
