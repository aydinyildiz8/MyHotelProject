using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RapidApiConsume.Models;
using Newtonsoft.Json;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIdController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {

            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiLocationSearchViewModel> list = new List<BookingApiLocationSearchViewModel>();

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "fa48e33451msh76e72f0777ec4cep19159ajsn516a9a848a48" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(list.Take(1).ToList());
                }
            }
            else
            {
                List<BookingApiLocationSearchViewModel> list = new List<BookingApiLocationSearchViewModel>();

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=paris&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "fa48e33451msh76e72f0777ec4cep19159ajsn516a9a848a48" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(list.Take(1).ToList());
                }
            }
        }

    }
}
