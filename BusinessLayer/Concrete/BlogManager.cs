using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void Add(Blog entity)
        {
            //business rules
            _blogDal.Insert(entity);
        }

        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }
        public List<Blog> GetLastBlogs(int count)
        {
            return _blogDal.GetAll().Take(count).ToList();
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetAll(x => x.BlogId == id);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetAll(x => x.WriterId == id);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        
    }
}
