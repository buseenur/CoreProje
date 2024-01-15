using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.Areas.Writer.ViewComponents
{
	public class Notification : ViewComponent
	{
		AnnouncementManager announcement = new AnnouncementManager(new EfAnnouncement());

		public IViewComponentResult Invoke()
		{
			var values = announcement.GetList().Take(5).ToList();
			return View(values);
		}
		
	}
}

