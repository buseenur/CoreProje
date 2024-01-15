using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.Dashboard
{
	public class ToDoListPanel : ViewComponent
	{
		ToDoListManager ToDoList = new ToDoListManager(new EfToDoList());

		public IViewComponentResult Invoke()
		{
			var values = ToDoList.GetList();
			return View(values);
		}
	}
}

