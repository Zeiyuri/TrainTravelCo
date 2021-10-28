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
    [Route("train")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private TrainManager _trainManager = new();
        [HttpPost]
        public void CreateTrain(Train trainToCreate)
        {
            _trainManager.CreateTrain(trainToCreate);
        }
        [HttpGet]
        public List<Train> ListTrains()
        {
            return _trainManager.ListTrains();
        }
    }
}
