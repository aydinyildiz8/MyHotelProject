using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult ContactAdd(Contact contact)
        {
            contact.ContactDate= Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(contact);
            return Ok();
        }
    }
}
