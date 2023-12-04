using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS_App.Data;
using EMS_App.Models;

namespace EMS_App.Controllers
{
    public class TicketsController : Controller
    {
        private readonly EMSContext _context;

        public TicketsController(EMSContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
              return _context.Ticket != null ? 
                          View(await _context.Ticket.ToListAsync()) :
                          Problem("Entity set 'EMSContext.Ticket'  is null.");
        }

        private bool TicketExists(int id)
        {
          return (_context.Ticket?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: /Tickets/Checkout/ 
        [HttpPost]
        public ActionResult Checkout(ICollection<Ticket> model)
        {
            return View(model);
        }
    }
}
