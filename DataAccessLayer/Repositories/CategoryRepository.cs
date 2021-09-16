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
    public class CategoryRepository : ICategoryDal
    {
        private Context _context = new Context();

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.SingleOrDefault(c => c.CategoryId == id);
        }

        public void Insert(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
        }
    }
}
