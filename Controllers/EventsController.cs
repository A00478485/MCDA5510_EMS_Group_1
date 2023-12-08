using Microsoft.AspNetCore.Mvc;

namespace EMS_App.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
