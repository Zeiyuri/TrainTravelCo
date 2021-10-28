using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCoNew.Models;

namespace TrainTravelCoNew.Data
{
    public class DataStorage
    {
        private static DataStorage _instance;
        private List<Train> _trains;
        private List<Trip> _trips;
        public static DataStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataStorage();
                }
                return _instance;
            }
        }
        private DataStorage()
        {
            _trains = new List<Train>()
            {
                new Train(){ RegNumber = "ABC123", MaxCapacity = 2},
                new Train(){ RegNumber = "CBA321", MaxCapacity = 4}

            };
            _trips = new List<Trip>()
            {
                new Trip(){Origin = "Orebro", Destination = "Stockholm", DepartureTime = "08:45", TrainToDestination = _trains[0] },
                new Trip(){Origin = "Stockholm", Destination = "Orebro", DepartureTime = "12:30", TrainToDestination = _trains[1] },
                new Trip(){Origin = "Orebro", Destination = "Gothenburg", DepartureTime = "14:40", TrainToDestination = _trains[1] }
            };

        }
        public void CreateTrain(Train trainToCreate)
        {
            _trains.Add(trainToCreate);
        }
        public List<Train> ListTrains()
        {
            return _trains;
        }
        public void CreateTrip(Trip tripToCreate)
        {
            _trips.Add(tripToCreate);
        }
        public List<Trip> ListTrips()
        {
            return _trips;
        }

    }
}
