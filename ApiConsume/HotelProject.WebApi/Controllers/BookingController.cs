using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult BookingAdd(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult BookingDelete(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult BookingUppdate(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BookingGetByID(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }

        [HttpPut("UpdateBookingChangeStatus")]
        public IActionResult UpdateBookingChangeStatus(Booking booking)
        {
            _bookingService.TBookingStatusChangeApproved(booking);
            return Ok();
        }

        [HttpPut("UpdateBookingChangeStatusID/{id}")]
        public IActionResult UpdateBookingChangeStatusID(int id)
        {
            _bookingService.TBookingStatusChangeApprovedID(id);
            return Ok();
        }

        [HttpPut("UpdateBookingChangeStatusCancelID/{id}")]
        public IActionResult UpdateBookingChangeStatusCancelID(int id)
        {
            _bookingService.TBookingStatusChangeApprovedCancelID(id);
            return Ok();
        }

        [HttpGet("LastSixBooking")]
        public IActionResult LastSixBooking()
        {
            var values = _bookingService.TLastSixBooking();
            return Ok(values);
        }

    }
}
