using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RezervacniSystem.Models;
using RezervacniSystem.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RezervacniSystem.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }

        public IActionResult Create()
        {
            _reservationService.createReservation(new Order("Pepa", 1, new List<string> { }, 5, 7));
            return new JsonResult("Objednavka vytvorena");
        }

    }
}
