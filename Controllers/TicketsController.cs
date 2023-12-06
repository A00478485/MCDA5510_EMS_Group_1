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

        // GET: /Tickets/Checkout/ 
        [HttpPost]
        public ActionResult ProceedtoCheckout(ICollection<Ticket> model)
        {
            CheckoutView checkoutView = new CheckoutView();
            checkoutView.Ticket = model.ToList();
            return View("Checkout", checkoutView);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutView model)
        {
            //if (ModelState.IsValid)
            {
                model.purchase.Created = DateTime.Now;
                model.purchase.BCity = "Halifax";
                _context.Purchase.Add(model.purchase);
                _context.SaveChanges();
            }
            return View(model);
        }
    }
}
