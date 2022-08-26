using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezervacniSystem.Models
{
    public class Order
    {
        public string Name { get; set; }
        public int RequestedCapacity { get; set; }

        public List<string> RequestedEquipment { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public Order()
        {
        }
    }
}
