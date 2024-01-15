using System;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.Areas.Writer.ViewComponents
{
	public class NavbarPicture : ViewComponent
	{
		private readonly UserManager<WriterUser> _userManager;

        public NavbarPicture(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.v = values.ImageUrl;
			return View(values);
		}
		
	}
}

