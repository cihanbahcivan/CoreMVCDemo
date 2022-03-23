using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCDemo.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var values = _writerManager.GetById(1);
            return View(values);
        }
    }
}
