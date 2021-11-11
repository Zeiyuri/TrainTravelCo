using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTravelCoNew.Models
{
    public class Trip
    {

        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }
        public Train TrainToDestination { get; set; }
        public List<Booking> AllBookings { get; set; }
        public int Id { get; private set; }
        private static int _idCount = 0;

        public Trip()
        {
            AllBookings = new List<Booking>();
            Id = _idCount;
            _idCount += 1;
        }
        public Trip(int id)
        {
            AllBookings = new List<Booking>();
            Id = id;
            
        }

    }
}


