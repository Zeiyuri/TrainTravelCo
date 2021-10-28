using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTravelCoNew.Models
{
    public class TripListDTO
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }
        public Train TrainToDestination { get; set; }
        public int Id { get; set; }
    }
}
