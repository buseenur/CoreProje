using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreProjeUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DefaultController : Controller
    {
        AnnouncementManager announcement = new AnnouncementManager(new EfAnnouncement());

        public IActionResult Index()
        {
            var values = announcement.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            Announcement announcementt = announcement.TGetById(id);
            return View(announcementt);
        }
    }
}

