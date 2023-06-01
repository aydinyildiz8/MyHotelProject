using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Geçilemez...")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Geçilemez...")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Geçilemez...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Geçilemez...")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Geçilemez...")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor. Kontrol Edip Tekrar Giriniz...")]
        public string ConfirmPassword { get; set; }
       
    }
}
