using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using HotelProject.WebUI.Dtos.FollowersDto;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/aydinyildiz8"),
                Headers =
    {
        { "X-RapidAPI-Key", "fa48e33451msh76e72f0777ec4cep19159ajsn516a9a848a48" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollewersDto resultInstagramFollewersDtos = JsonConvert.DeserializeObject<ResultInstagramFollewersDto>(body);
                ViewBag.insFollowing = resultInstagramFollewersDtos.following;
                ViewBag.insFollowers = resultInstagramFollewersDtos.followers;

            }



            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=aydinyldz8"),
                Headers =
    {
        { "X-RapidAPI-Key", "fa48e33451msh76e72f0777ec4cep19159ajsn516a9a848a48" },
        { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response2 = await client.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultTwitterFollewersDto resultTwitterFollewersDto = JsonConvert.DeserializeObject<ResultTwitterFollewersDto>(body2);
                ViewBag.twFollowing = resultTwitterFollewersDto.data.user_info.friends_count;
                ViewBag.twsFollowers = resultTwitterFollewersDto.data.user_info.followers_count;
            }




            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Faydinyildiz8%2F"),
                Headers =
    {
        { "X-RapidAPI-Key", "fa48e33451msh76e72f0777ec4cep19159ajsn516a9a848a48" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ResultLinkedinFollewersDto resultLinkedinFollewersDto = JsonConvert.DeserializeObject<ResultLinkedinFollewersDto>(body3);
                ViewBag.linkedinFollowers = resultLinkedinFollewersDto.data.followers_count;
            }























            return View();
        }
    }
}
