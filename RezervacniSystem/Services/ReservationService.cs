using RezervacniSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezervacniSystem.Services
{
    public class ReservationService : IReservationService
    {
        private readonly List<Room> _rooms;

        public ReservationService()
        {
            _rooms = new List<Room>
            {
                new Room(0, 2, new List<string> { })
            };

        }

        public Reservation createReservation(Order o)
        {
            Room nalezenyPokoj = najdiVhodnyPokoj(o);

            // tmto pristupem (kdy porovnavam pokoj s null) jsem ztratil informaci o tom, jesli neexistuje vhodn pokoj nebo byly vsechny plne
            if (nalezenyPokoj == null)
            {
                Console.WriteLine("Reservation nebyla vytvořena");
                return null;
            }


            Reservation r = new Reservation(o.Name, o.Start, o.End);
            nalezenyPokoj.Reservations.Add(r);
            Console.WriteLine("Reservation vytvořena, Cislo pokoje =" + nalezenyPokoj.Id);
            return r;

        }

        private Room najdiVhodnyPokoj(Order o)
        {
            for (int i = 0; i < _rooms.Count; i++)
            {
                // tady jsem použil continue, aby se vzhnul jedne urovni zanožení, abych nemusel dat kod hledani terminu pod if
                if (_rooms[i].Capacity < o.RequestedCapacity)
                {
                    continue;
                }

                bool pokojJeVhodny = true;
                List<Reservation> ReservationList = _rooms[i].Reservations;
                for (int j = 0; j < ReservationList.Count; j++)
                {
                    bool nekoliduje = nekolidujeOrderAReservationNaPokoji(o, ReservationList[i]);
                    if (!nekoliduje)
                    {
                        pokojJeVhodny = false;
                        break;
                    }
                }
                // teprvé potom, co jsme prošli všechny Reservation na kokoj a ani jedna nekolidovala, víme že pokoj je vhodný a vrátím jej
                if (pokojJeVhodny)
                {
                    return _rooms[i];
                }
            }
            //to že jsme nenašli vhodný pokoj dáme najevo tím, že místo určitého pokoje vrátíme null
            return null;
        }



        private bool nekolidujeOrderAReservationNaPokoji(Order o, Reservation Reservation)
        {
            // jsem asi předtim tu podminku pro nekolidujici objednavku nevymslilel dobře
            return o.End < Reservation.Start || o.Start > Reservation.End;
        }

    }
}
