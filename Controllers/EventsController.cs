using EMS_App.Data;
using EMS_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS_App.Controllers
{
    public class EventsController : Controller
    {
        private readonly EMSContext eMSContext;

        public EventsController(EMSContext eMSContext)
        {
            this.eMSContext = eMSContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var events = await eMSContext.events.ToListAsync<Event>();
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
