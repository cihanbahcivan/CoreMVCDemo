using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCDemo.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        private NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = _notificationManager.GetAll();
            return View(values);
        }
    }
}
