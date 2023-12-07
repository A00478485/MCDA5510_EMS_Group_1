using EMS_App.Data;
using EMS_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS_App.Controllers
{
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.User.Add(obj);
                _db.SaveChanges();
                TempData["SignUp"] = "You are Registered. Good work!";
                return RedirectToAction("Login", "User");
            }
            return View();
        }
    }
}
