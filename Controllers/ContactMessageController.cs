using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreProjeUI.Controllers
{
    public class ContactMessageController : Controller
    {
        MessageManager messageManeger = new MessageManager(new EfMessage());

        public IActionResult Index()
        {
            var values = messageManeger.GetList();
            return View(values);
        }

        public IActionResult DeleteContact(int id)
        {
            var values = messageManeger.TGetById(id);
            messageManeger.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult DetailsContact(int id)
        {
            var values = messageManeger.TGetById(id);
            return View(values);
        }
    }
}

