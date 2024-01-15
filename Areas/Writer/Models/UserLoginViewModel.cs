using System;
using System.ComponentModel.DataAnnotations;

namespace CoreProjeUI.Areas.Writer.Models
{
	public class UserLoginViewModel
	{
		[Display(Name = "Kullanıcı Adı")]
		[Required(ErrorMessage ="Kullanıcı adını girin...")]
		public string UserName { get; set; }

		[Display(Name = "Şifre")]
		[Required(ErrorMessage ="Şifreyi girin...")]
		public string Password { get; set; }

	}
}

