using EMS_App.Data;
using EMS_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS_App.Controllers
{
    public class ProgramController : Controller
    {
        private readonly EMSContext eMSContext;

        public ProgramController(EMSContext eMSContext)
        {
            this.eMSContext = eMSContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var events = await eMSContext.events.ToListAsync();
            var newEve = events.OrderBy(m => m.eventStartTime).ToList();
            return View(newEve);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Models.Program e)
        {
            var ent = new Models.Program()
            {
                eventDescription = e.eventDescription,
                eventID = new Guid(),
                eventHeader = e.eventHeader,
                eventStartTime = e.eventStartTime,
                eventEndTime = e.eventEndTime,
                eventShortDescription = e.eventShortDescription
            };

            await eMSContext.events.AddAsync(ent);
            await eMSContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
