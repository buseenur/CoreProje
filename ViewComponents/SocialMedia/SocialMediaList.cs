using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.SocialMedia
{
	public class SocialMediaList : ViewComponent
	{
		SocialMediaManager SocialMedia = new SocialMediaManager(new EfSocialMedia());

		public IViewComponentResult Invoke()
		{
			var values = SocialMedia.GetList();
			return View(values);
		}
	}
}

