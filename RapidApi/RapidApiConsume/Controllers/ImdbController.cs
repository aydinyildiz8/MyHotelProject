using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RapidApiConsume.Models;
using Newtonsoft.Json;

namespace RapidApiConsume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> list = new List<ApiMovieViewModel>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "fa48e33451msh76e72f0777ec4cep19159ajsn516a9a848a48" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                list = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(list);
                
            }
        }
    }
}
