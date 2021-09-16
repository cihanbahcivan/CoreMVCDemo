using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal
    {
        List<Blog> GetAll();
        Blog GetById(int id);
        void Insert(Blog blog);
        void Update(Blog blog);
        void Delete(Blog blog);
    }
}
