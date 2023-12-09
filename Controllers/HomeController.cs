using EMS_App.Data;
using EMS_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EMS_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EMSContext _db;


        public HomeController(ILogger<HomeController> logger, EMSContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<Event> events = _db.Event.ToList();
            List<Speaker> speakers = _db.Speaker.ToList();

            var combinedModel = new Tuple<IEnumerable<Event>, IEnumerable<Speaker>>(events, speakers);

            return View(combinedModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}