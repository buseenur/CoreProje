using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.Dashboard
{
	public class AdminNavbarMessageList : ViewComponent
	{
		WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessage());

		public IViewComponentResult Invoke()
		{
			string p = "admin@gmail.com";
			var values = writerMessageManager.GetListReceiverMessage(p).OrderByDescending(x => x.WriterMessageId).Take(3).ToList();
			return View(values);
		}
	}
}

