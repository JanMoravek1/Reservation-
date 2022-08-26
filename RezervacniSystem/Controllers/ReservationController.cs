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
            //Reservation r = _reservationService.createReservation(new Order{Name:"Pepa");
            // return new JsonResult(r);
            return new JsonResult(null);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order o)
        {
            Reservation r = _reservationService.createReservation(o);
            return new JsonResult(r);
        }

    }
}
