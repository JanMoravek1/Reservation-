using RezervacniSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezervacniSystem.Services
{
    public interface IReservationService
    {
        public void createReservation(Order o);
    }
}
