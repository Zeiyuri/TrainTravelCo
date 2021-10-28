using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCoNew.Data;
using TrainTravelCoNew.Models;

namespace TrainTravelCoNew.Managers
{
    public class BookingManager
    {
        public List<TripListDTO> Search(string origin)
        {
            bool isFull = false;
            List<Trip> temp = new();
            for (int i = 0; i < DataStorage.Instance.ListTrips().Count; i++)
            {
                temp.Add(DataStorage.Instance.ListTrips()[i]);
            }
            
            
            for (int i = 0; i < temp.Count; i++)
            {
                if(temp[i].Origin != origin)
                {
                    temp.RemoveAt(i);
                    --i;
                }
            }
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].AllBookings.Count >= temp[i].TrainToDestination.MaxCapacity)
                {
                    isFull = true;
                }
                if (isFull)
                {
                    temp.RemoveAt(i);
                    isFull = false;
                    --i;
                }
            }

            var dtoList = new List<TripListDTO>();
            for (int i = 0; i < temp.Count; i++)
            {
                dtoList.Add(new TripListDTO() { Origin = temp[i].Origin, DepartureTime = temp[i].DepartureTime, Destination = temp[i].Destination, TrainToDestination = temp[i].TrainToDestination, Id = temp[i].Id });
            }


            return dtoList;
        }
        public string BookTrip(int id, Customer customer)
        {
            foreach (var item in DataStorage.Instance.ListTrips())
            {
                if(item.Id == id)
                {
                    if(item.AllBookings.Count < item.TrainToDestination.MaxCapacity)
                    {
                        var newBooking = new Booking()
                        {
                            RegisteredCustomer = customer,
                            RegisteredTrip = item
                        };
                        item.AllBookings.Add(newBooking);
                        return "Booking Successful";
                    }
                    else
                    {
                        return "Train already full.";
                    }
                    
                }
            }
            return "No Trip matched given ID.";
        }
    }
}
