using System;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.Dashboard
{
	public class Last5Projects : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

