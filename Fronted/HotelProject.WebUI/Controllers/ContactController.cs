using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.MessageCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:32685/api/MessageCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);

            List<SelectListItem> messageCategories = (from x in values
                                                      select new SelectListItem
                                                      {
                                                          Text = x.MessageCategoryName,
                                                          Value = x.MessageCategoryID.ToString()
                                                      }).ToList();
            messageCategories.Insert(0, new SelectListItem { Text = "Konu Başlığını Seçiniz", Value = "" });
            ViewBag.v = messageCategories;

            return View();
        }


        [HttpGet]
        public PartialViewResult _SendMessage()
        {

            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _SendMessage(CreateContactDto createContactDto)
        {
            createContactDto.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:32685/api/ReceiveMessage", stringContent);

            return RedirectToAction("Index", "Default");
        }
    }
}
