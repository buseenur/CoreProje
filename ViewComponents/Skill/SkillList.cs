using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.Skill
{
	public class SkillList : ViewComponent
	{
		SkillManager skillManager = new SkillManager(new EfSkill());

		public IViewComponentResult Invoke()
		{
			var values = skillManager.GetList();
			return View(values);
		}
		
	}
}

