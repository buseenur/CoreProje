using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.Feature
{
	public class FeatureList : ViewComponent
	{
		FeatureManager featureManager = new FeatureManager(new EfFeature());

		public IViewComponentResult Invoke()
		{
			var values = featureManager.GetList();
			return View(values);
		}
	}
}

