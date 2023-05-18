using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult TokenOlustur()
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [HttpGet("[action]")]
        public IActionResult AdminTokenOlustur()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult TokenOlusturTest()
        {
            return Ok("Hoşgeldiniz");
        }

        [Authorize(Roles = "Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult AdminTokenOlusturTest()
        {
            return Ok("Başarılı Bir Şekilde Giriş Yapıldı.");
        }

    }
}
