using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeUI.ViewComponents.Testimonial
{
	public class TestimonialList : ViewComponent
	{
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonial());

        public IViewComponentResult Invoke()
		{
			var values = testimonialManager.GetList();
			return View(values);
		}
	}
}

