﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void Add(Blog blog);
        void Update(Blog blog);
        void Delete(Blog blog);
        List<Blog> GetAll();
        Blog GetById(int id);
        List<Blog> GetBlogById(int id);
    }
}
