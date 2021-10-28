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
    [Route("trip")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private TripManager _tripManager = new();
        [HttpPost]
        public string CreateTrip(TripDTO dto)
        {
            return _tripManager.CreateTrip(dto);
        }
        [HttpGet]
        public List<TripListDTO> ListTrips()
        {
            return _tripManager.ListTrips();
        }
    }
}
