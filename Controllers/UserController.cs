using Microsoft.AspNetCore.Mvc;

namespace EMS_App.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
