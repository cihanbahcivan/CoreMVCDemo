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
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }
        public void Add(NewsLetter entity)
        {
            _newsLetterDal.Insert(entity);
        }

        public void Update(NewsLetter entity)
        {
            _newsLetterDal.Update(entity);
        }

        public void Delete(NewsLetter entity)
        {
            _newsLetterDal.Delete(entity);
        }

        public List<NewsLetter> GetAll()
        {
            return _newsLetterDal.GetAll();
        }

        public NewsLetter GetById(int id)
        {
            return _newsLetterDal.GetById(id);
        }
    }
}
