using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCoNew.Data;
using TrainTravelCoNew.Models;

namespace TrainTravelCoNew.Managers
{
    public class TripManager
    {
        public string CreateTrip(TripDTO DTO)
        {
            List<Train> temp = DataStorage.Instance.ListTrains();
            bool trainFound = false;
            foreach (var item in temp)
            {
                if(item.Id == DTO.TrainId)
                {
                    var tripToCreate = new Trip()
                    {
                        Origin = DTO.Origin,
                        Destination = DTO.Destination,
                        DepartureTime = DTO.DepartureTime,
                        TrainToDestination = item
                    };
                    DataStorage.Instance.CreateTrip(tripToCreate);
                    trainFound = true;
                    break;
                }
            }
            if (trainFound)
            {
                return "Trip Created";
            }
            else
            {
                return "Train with inserted ID not found.";
            }

        }
        public List<TripListDTO> ListTrips()
        {
            List<Trip> temp = DataStorage.Instance.ListTrips();
            var dtoList = new List<TripListDTO>();
            for (int i = 0; i < temp.Count; i++)
            {
                dtoList.Add(new TripListDTO() {Origin = temp[i].Origin, DepartureTime = temp[i].DepartureTime, Destination = temp[i].Destination, TrainToDestination = temp[i].TrainToDestination, Id = temp[i].Id });
            }

            return dtoList;
        }
        
    }
}
