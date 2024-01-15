using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.Portfolio
{
	public class SilideList : ViewComponent
	{
		PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolio());

		public IViewComponentResult Invoke()
		{
			var values = portfolioManager.GetList();
			return View(values);
		}
	}
}

