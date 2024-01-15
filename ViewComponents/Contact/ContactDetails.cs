using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.Contact
{
	public class ContactDetails : ViewComponent
	{
		ContactManager contactManager = new ContactManager(new EfContact());

		public IViewComponentResult Invoke()
		{
			var values = contactManager.GetList();
			return View(values);
		}
	}
}

