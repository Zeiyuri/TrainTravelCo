using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCoNew.Managers;
using TrainTravelCoNew.Models;

namespace TrainTravelCoNew.Controllers
{
    [Route("booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingManager _bookingManager = new();
        [HttpGet]
        public List<TripListDTO> Search([FromQuery]string start)
        {
            return _bookingManager.Search(start);
        }
        [HttpPost]
        public string BookTrip(BookingDTO dto)
        {
            var newCustomer = new Customer()
            {
                Name = dto.CustomerName,
                PhoneNumber = dto.CustomerPhoneNumber
            };
            return _bookingManager.BookTrip(dto.TripID, newCustomer);
        }

    }
}
