using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private EfCategoryRepository _efCategoryRepository;

        public CategoryManager()
        {
            _efCategoryRepository = new EfCategoryRepository();
        }

        //public CategoryManager(CategoryRepository categoryRepository)
        //{
        //    _efCategoryRepository = categoryRepository;
        //}
        public void Add(Category category)
        {
            _efCategoryRepository.Insert(category);
        }

        public void Update(Category category)
        {
            _efCategoryRepository.Update(category);
        }

        public void Delete(Category category)
        {
            _efCategoryRepository.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _efCategoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _efCategoryRepository.GetById(id);
        }
    }
}
