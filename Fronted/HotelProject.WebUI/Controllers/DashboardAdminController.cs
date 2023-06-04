using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class DashboardAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
