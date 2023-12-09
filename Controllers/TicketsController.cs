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
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace EMS_App.Controllers
{
    public class TicketsController : Controller
    {
        private readonly EMSContext _context;

        public TicketsController(EMSContext context)
        {
            _context = context;
        }

        [Authorize]
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
            checkoutView.Purchase.Uemail = User.Identity.Name;
            return View("Checkout", checkoutView);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutView model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var dbContextTransaction = _context.Database.BeginTransaction())
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
                                if (ava != null)
                                {
                                    ava.Availability = ava.Availability - ticketpurchase.Quantity;
                                    _context.Update(ava);
                                }
                                _context.SaveChanges();
                            }
                        }
                        dbContextTransaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    return View("Status", model);
                }
                //return RedirectToAction("Status", new { OrderId = model.Purchase.OrderId});
                return View("Status", model);
            }
            return View(model);
        }
        public IActionResult Status(CheckoutView checkout)
        {
            return View(checkout);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidateCard([Bind(Prefix = "Payment.CardNumber")] long CardNumber, [Bind(Prefix = "Payment.CardName")] String CardName, [Bind(Prefix = "Payment.CardType")] String CardType)
        {
            String numberString = CardNumber.ToString();

            if (numberString.Length < 15 || numberString.Length > 16)
            {
                return Json($"Invalid Card Length");
            }
            if (CardType.Equals("Visa"))
            {
                if (!(numberString.StartsWith("4") && numberString.Length == 16))
                {
                    return Json($"Invalid Visa Card Number");
                }
            }
            if (CardType.Equals("Master Card"))
            {
                int CardNumberPrefix = int.Parse(numberString.Substring(0, 2));
                if (!((CardNumberPrefix >= 51 && CardNumberPrefix <= 55) && numberString.Length == 16))
                {
                    return Json($"Invalid Master Card Number");
                }
            }
            if (CardType.Equals("American Express"))
            {
                if (numberString.Length != 15)
                {
                    return Json($"Invalid American Express Number");
                }
                if (!(numberString.StartsWith("34") || numberString.StartsWith("37")))
                {
                    return Json($"Invalid American Express Number");
                }
            }
            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidatePostalCode([Bind(Prefix = "Billing.BPostalCode")] String PostalCode, [Bind(Prefix = "Billing.BCountry")] String Country)
        {
            if (Country.Equals("United State"))
            {
                if (!Regex.Match(PostalCode, "^[0-9]{5}(?:-[0-9]{4})?$").Success)
                    return Json($"Invalid US Postal Code");
            }
            else if (Country.Equals("Canada"))
            {
                if (!Regex.Match(PostalCode.ToUpper(), "^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] [0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$").Success)
                    return Json($"Invalid CA Postal Code");
            }
            return Json(true);
        }
    }
}
