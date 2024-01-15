using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreProjeUI.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EfWriterMessage());

        public IActionResult ReceiverMessageList()
        {
            string x;
            x = "admin@gmail.com";
            var values = messageManager.GetListReceiverMessage(x); //alıcısı olduğumuz mesajlar için
            return View(values);
        }

        public IActionResult SenderMessageList()
        {
            string x;
            x = "admin@gmail.com";
            var values = messageManager.GetListSenderMessage(x); //göndericisi olduğumuz mesajlar için
            return View(values);
        }

        public IActionResult AdminMessageDetails(int id)
        {
            var values = messageManager.TGetById(id);
            return View(values);
        }

        public IActionResult AdminMessageDelete(int id)
        {
            //string p;
            //p = "admin@gmail.com"; //ÜÇÜNCÜ YÖNTEM

            string ViewUrl = TempData["DeleteUrl"].ToString(); //İKİNCİ YÖNTEM
            var values = messageManager.TGetById(id);
            messageManager.TDelete(values);


            // ÜÇÜNCÜ YÖNTEM
            //if (values.Receiver == p)
            //{
            //    messageManager.TDelete(values);
            //    return RedirectToAction("ReceiverMessageList");
            //}
            //else
            //{
            //    messageManager.TDelete(values);
            //    return RedirectToAction("SenderMessageList");
            //}

            return RedirectToAction(ViewUrl);

            // BİRİNCİ YÖNTEM
            //if (values.SenderName != null)
            //{
            //    return RedirectToAction("SenderMessageList");
            //}
            //else
            //{
            //    return RedirectToAction("ReceiverMessageList");
            //}
            
        }

        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage writerMessage)
        {
            writerMessage.Sender = "admin@gmail.com";
            writerMessage.SenderName = "Admin";
            writerMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.SurName).FirstOrDefault();
            writerMessage.ReceiverName = usernamesurname;
            messageManager.TAdd(writerMessage);
            return RedirectToAction("SenderMessageList");
        }
    }
}

