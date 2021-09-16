using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories
{
    public class BlogRepository : IBlogDal
    {
        public List<Blog> GetAll()
        {
            using var _context = new Context();
            return _context.Blogs.ToList();
        }

        public Blog GetById(int id)
        {
            using var _context = new Context();
            return _context.Blogs.SingleOrDefault(c => c.BlogID == id);
        }

        public void Insert(Blog blog)
        {
            using var _context = new Context();
            _context.Add(blog);
            _context.SaveChanges();
        }

        public void Update(Blog blog)
        {
            using var _context = new Context();
            _context.Update(blog);
            _context.SaveChanges();
        }

        public void Delete(Blog blog)
        {
            using var _context = new Context();
            _context.Remove(blog);
            _context.SaveChanges();
        }
    }
}
