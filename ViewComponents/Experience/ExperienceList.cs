using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.Experience
{
	public class ExperienceList : ViewComponent
	{
		ExperienceManager experienceManager = new ExperienceManager(new EfExperience());

		public IViewComponentResult Invoke()
		{
			var values = experienceManager.GetList();
			return View(values);
		}
	}
}

