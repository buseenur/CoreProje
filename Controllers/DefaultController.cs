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

namespace CoreProjeUI.Controllers
{
    [AllowAnonymous]
   
    public class DefaultController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FooterPartial()
        {
            return View();
        }

        public IActionResult NavbarPartial()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SendMessage(Message message)
        {
            MessageManager messageManager = new MessageManager(new EfMessage());

            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Status = true;
            messageManager.TAdd(message);
            return PartialView();
        }

        public PartialViewResult JavaScript()
        {
            return PartialView();
        }
    }
}


