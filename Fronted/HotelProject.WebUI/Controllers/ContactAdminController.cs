using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
   
    public class ContactAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public async Task<IActionResult> Inbox() //Gelen Kutusu
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:32685/api/ReceiveMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);

                await ReceiveMessageCount();
                await SendMessageCount();
                return View(values);
            }

            return View();
        }



        public async Task<IActionResult> SendBox() //Giden Kutusu
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:32685/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxContactDto>>(jsonData);
                await ReceiveMessageCount();
                await SendMessageCount();

                return View(values);
            }

            return View();
        }



        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }



        [HttpGet]
        public IActionResult AddSendMessage() // Yeni Mesaj Oluşturma
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageContactDto createSendMessageContactDto) // Yeni Mesaj Oluşturma
        {
            createSendMessageContactDto.SenderMail = "aydnyldz8@gmail.com";
            createSendMessageContactDto.SenderName = "Admin";
            createSendMessageContactDto.SendMessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessageContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:32685/api/SendMessage", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> ReceiveMessageDetails(int id) //Gelen Mesaj Detayı
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:32685/api/ReceiveMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ReceiveMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> SendMessageDetails(int id) //Gönderilen Mesaj Detayı
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:32685/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<SendMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }



        [HttpGet("GetReceiveMessageCount")]
        public async Task<IActionResult> ReceiveMessageCount() //Gelen Mesaj Sayısı
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:32685/api/ReceiveMessage/GetReceiveMessageCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var count = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.receiveMessageCount = count;
            }
            return PartialView("SideBarAdminContactPartial");
        }



        [HttpGet("GetSendMessageCount")]
        public async Task<IActionResult> SendMessageCount() //Giden Mesaj Sayısı
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:32685/api/SendMessage/GetSendMessageCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var count = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount = count;
            }
            return PartialView("SideBarAdminContactPartial");
        }


    }
}
