using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AboutAdd(About about)
        {
            _aboutService.TInsert(about);
            return Ok();
        }



        [HttpDelete("{id}")]
        public IActionResult AboutDelete(int id)
        {
            var values = _aboutService.TGetById(id);
            _aboutService.TDelete(values);
            return Ok();
        }


        [HttpPut]
        public IActionResult AboutUpdate(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();
        }


        [HttpGet("{id}")]
        public IActionResult AboutGet(int id)
        {
            var values = _aboutService.TGetById(id);
            return Ok(values);
        }
    }
}
