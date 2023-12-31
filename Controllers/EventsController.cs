﻿using EMS_App.Data;
using EMS_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EMS_App.Controllers
{
    public class EventsController : Controller
    {
        private readonly EMSContext _db;

        public EventsController(EMSContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Event> events = _db.Event.ToList();
                        return View();


        }
    }
}
