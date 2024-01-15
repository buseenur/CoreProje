using System;
using System.ComponentModel.DataAnnotations;

namespace CoreProjeUI.Areas.Writer.Models
{
	public class UserRegisterViewModel
	{
        [Required(ErrorMessage = "Adınızı Girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadınızı Girin")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Resim Url Değeri Girin")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adını Girin")]
		public string UserName { get; set; }

        [Required(ErrorMessage = "Şifreyi Girin")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreyi Tekrar Girin")]
		[Compare("Password",ErrorMessage ="Şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Mail Girin")]
        public string Mail { get; set; }
	}
}

