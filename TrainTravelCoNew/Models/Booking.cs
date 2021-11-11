using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTravelCoNew.Models
{
    public class Booking
    {
        public Customer RegisteredCustomer { get; set; }
        public Trip RegisteredTrip { get; set; }
        public Booking(Customer customer)
        {
            RegisteredCustomer = customer;
        }
    }
}
