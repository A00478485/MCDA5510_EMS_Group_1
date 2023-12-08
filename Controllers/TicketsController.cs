using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS_App.Data;
using EMS_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;

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
            checkoutView.Purchase = new Purchase();
            checkoutView.Purchase.Uemail = "ac@asd.com";
            return View("Checkout", checkoutView);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutView model)
        {
            if (ModelState.IsValid)
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Billing.Add(model.Billing);
                        _context.Payment.Add(model.Payment);
                        _context.SaveChanges();
                        model.Purchase.BillingId = model.Billing.BillingId;
                        model.Purchase.PaymentId = model.Payment.PaymentId;
                        model.Purchase.Created = DateTime.Now;
                        _context.Purchase.Add(model.Purchase);
                        _context.SaveChanges();
                        TicketPurchase ticketpurchase = new TicketPurchase();
                        for (int i = 0; i < model.Ticket.Count; i++)
                        {
                            if (model.Ticket[i].Quantity > 0)
                            {
                                ticketpurchase.OrderId = model.Purchase.OrderId;
                                ticketpurchase.TicketId = model.Ticket[i].TicketId;
                                ticketpurchase.Quantity = model.Ticket[i].Quantity;
                                _context.TicketPurchase.Add(ticketpurchase);
                                var ava = _context.Ticket.Find(ticketpurchase.TicketId);
                                ava.Availability = ava.Availability - ticketpurchase.Quantity;
                                _context.Update(ava);
                                _context.SaveChanges();
                            }
                        }
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        //Log, handle or absorbe I don't care ^_^
                    }
                }
                return RedirectToAction("Status", new { OrderId = model.Purchase.OrderId });
            }
            return View(model);
        }
        public IActionResult Status(int OrderId)
        {
            ViewData["OrderId"] = OrderId;
            return View();
        }

    }
}
