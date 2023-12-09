using EMS_App.Data;
using EMS_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS_App.Controllers
{
    public class SpeakerController : Controller
    {


        private readonly EMSContext _db;
        public SpeakerController(EMSContext db)
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
