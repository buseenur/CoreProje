using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.About
{
	public class AboutList : ViewComponent
	{
		AboutManager aboutManager = new AboutManager(new EfAbout());
		public IViewComponentResult Invoke()
		{
			var values = aboutManager.GetList();
			return View(values);
		}
	}
}

