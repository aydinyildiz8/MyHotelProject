using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveMessageController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ReceiveMessageController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult ContactAdd(Contact contact)
        {
            contact.ContactDate = Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(contact);
            return Ok();
        }

        [HttpGet]
        public IActionResult ContactInboxList()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetSendContactMessage(int id)
        {
            var values = _contactService.TGetById(id);
            return Ok(values);
        }

        [HttpGet("GetReceiveMessageCount")]
        public IActionResult GetReceiveMessageCount()
        {
            var value = _contactService.TGetContactCount();
            return Ok(value);
        }
    }
}
