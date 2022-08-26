using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezervacniSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public List<string> Equipment;
        public List<Reservation> Reservations = new List<Reservation>();

        public Room(int id, int capacity, List<string> equipment)
        {
            Id = id;
            Capacity = capacity;
            Equipment = equipment;
        }
    }
}
