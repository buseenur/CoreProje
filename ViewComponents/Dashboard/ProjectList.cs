using System;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.Dashboard
{
	public class ProjectList : ViewComponent
	{
		Context context = new Context();

		public IViewComponentResult Invoke()
		{
			var values = context.Portfolios.ToList();
			return View(values);
		}
	}
}

