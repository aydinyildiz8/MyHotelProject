using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez...")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Geçilemez...")]
        public string Password { get; set; }
    }
}
