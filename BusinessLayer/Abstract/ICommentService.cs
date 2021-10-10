using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void Add(Comment comment);
        //void Update(Comment comment);
        //void Delete(Comment comment);
        List<Comment> GetAll(int id);
        //Comment GetById(int id);
    }
}
