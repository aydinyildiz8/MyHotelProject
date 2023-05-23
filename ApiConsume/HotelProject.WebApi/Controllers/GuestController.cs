using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            var values = _guestService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult GuestAdd(Guest guest)
        {
            _guestService.TInsert(guest);
            return Ok();
        }

        [HttpPut]
        public IActionResult GuestUpdate(Guest guest)
        {
            _guestService.TUpdate(guest);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult GuestDelete(int id)
        {
            var values = _guestService.TGetById(id);
            _guestService.TDelete(values);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GuestGetByID(int id)
        {
            var value = _guestService.TGetById(id);
            return Ok(value);
        }
    }
}
