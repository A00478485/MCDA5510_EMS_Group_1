using EMS_App.Data;
using EMS_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS_App.Controllers
{
    public class SpeakerController : Controller
    {


        private readonly ApplicationDbContext _db;
        public SpeakerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Speaker> speakers = _db.Speaker.ToList();
            return View(speakers);

        }
    }
}
