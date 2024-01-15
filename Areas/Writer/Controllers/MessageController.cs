using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreProjeUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {

        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessage());

        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string message) //sessiondan gelen değer
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            message = values.Email;
            var messageList = writerMessageManager.GetListReceiverMessage(message);
            return View(messageList);
        }

        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string message) //sessiondan gelen değer
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            message = values.Email;
            var messageList = writerMessageManager.GetListSenderMessage(message);
            return View(messageList);
        }

        [Route("SenderMessageDetails/{id}")]
        public IActionResult SenderMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);
            return View(writerMessage);
        }

        [Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);
            return View(writerMessage);
        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage message) // ATAMA YAPMA İŞLEMİNİ SOR MANTIK?
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.SurName;
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Sender = mail;
            message.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == message.Receiver).Select(y => y.Name + " " + y.SurName).FirstOrDefault();
            message.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(message);
            return RedirectToAction("SenderMessage");
        }
    }
}

