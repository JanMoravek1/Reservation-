using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezervacniSystem.Models
{
    public class Reservation
    {
        public string Name { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public Reservation(string name, int start, int end)
        {
            Name = name;
            Start = start;
            End = end;
        }
    }
}
