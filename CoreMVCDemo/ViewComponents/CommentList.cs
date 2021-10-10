using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCDemo.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment()
                {
                    Id = 1,
                    Username = "Çiko"
                },
                new UserComment()
                {
                    Id = 2,
                    Username = "Murro",
                },
                new UserComment()
                {
                    Id = 3,
                    Username = "Sero"
                }
            };
            return View(commentValues);
        }
    }
}
