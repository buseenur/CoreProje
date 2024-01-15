using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.Service
{
	public class ServiceList : ViewComponent
	{
		ServiceManager serviceManager = new ServiceManager(new EfService());

		public IViewComponentResult Invoke()
		{
			var values = serviceManager.GetList();
			return View(values);
		}
	}
}

