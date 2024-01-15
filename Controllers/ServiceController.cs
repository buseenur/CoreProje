using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreProjeUI.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfService());
        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmetler Listesi";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmetler Listesi";

            var values = serviceManager.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.v1 = "Hizmet Ekleme";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Ekleme";

            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            ViewBag.v1 = "Hizmet Ekleme";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Ekleme";

            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.TGetById(id);
            serviceManager.TDelete(values);
            return View(values);
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewBag.v1 = "Hizmet Güncelleme";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Güncelleme";

            var values = serviceManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}

