using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clientStaff = _httpClientFactory.CreateClient();
            var responseMessageStaff = await clientStaff.GetAsync("http://localhost:32685/api/DashboardWidget/StaffCount");
            var jsonDataStaff = await responseMessageStaff.Content.ReadAsStringAsync();
            ViewBag.staffcount = jsonDataStaff;


            var clientBooking = _httpClientFactory.CreateClient();
            var responseMessageBooking = await clientBooking.GetAsync("http://localhost:32685/api/DashboardWidget/BookingCount");
            var jsonDataBooking = await responseMessageBooking.Content.ReadAsStringAsync();
            ViewBag.bookingcount = jsonDataBooking;


            var clientUser = _httpClientFactory.CreateClient();
            var responseMessageUser = await clientUser.GetAsync("http://localhost:32685/api/DashboardWidget/UsersCount");
            var jsonDataUser = await responseMessageUser.Content.ReadAsStringAsync();
            ViewBag.usercount = jsonDataUser;


            var clientRoom = _httpClientFactory.CreateClient();
            var responseMessageRoom = await clientRoom.GetAsync("http://localhost:32685/api/DashboardWidget/RoomCount");
            var jsonDataRoom = await responseMessageRoom.Content.ReadAsStringAsync();
            ViewBag.roomcount = jsonDataRoom;

            return View();
        }
    }
}
