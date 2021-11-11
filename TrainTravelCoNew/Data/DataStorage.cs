using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCoNew.Models;

namespace TrainTravelCoNew.Data
{
    public class DataStorage
    {
        private static DataStorage _instance;
        private string _filePath = @$"D:\Fullstack\TrainTravelCoNew\TrainTravelCoNew\DataStorage\";
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
            //AddDefaultTrainsAndTrips();
            CreateDirectoryFromPath();
        }
        public void CreateTrain(Train trainToCreate)
        {
            if (!Directory.Exists($"{_filePath}trains"))
            {
                Directory.CreateDirectory($"{_filePath}trains");
            }
            string completePath = @$"{_filePath}trains\train_{trainToCreate.Id}.txt";
            using (StreamWriter sw = new(completePath))
            {
                sw.WriteLine(trainToCreate.Id);
                sw.WriteLine(trainToCreate.RegNumber);
                sw.WriteLine(trainToCreate.MaxCapacity);
            }

        }
        public List<Train> ListTrains()
        {
            string[] filesInDirectory = Directory.GetFiles(@$"{_filePath}trains");
            List<Train> trainsToReturn = new();
            for (int i = 0; i < filesInDirectory.Length; i++)
            {
                filesInDirectory[i] = Path.GetFileName(filesInDirectory[i]);
                if (filesInDirectory[i].StartsWith("train_"))
                {
                    using (StreamReader sr = new(@$"{_filePath}\trains\{filesInDirectory[i]}"))
                    {
                        string id = sr.ReadLine();
                        string RegNr = sr.ReadLine();
                        string MaxCap = sr.ReadLine();
                        Train temp = new(int.Parse(id))
                        {
                            RegNumber = RegNr,
                            MaxCapacity = int.Parse(MaxCap)
                        };
                        trainsToReturn.Add(temp);
                    }
                }
            }
            return trainsToReturn;
        }
        public void CreateTrip(Trip tripToCreate)
        {
            if (!Directory.Exists($"{_filePath}trips"))
            {
                Directory.CreateDirectory($"{_filePath}trips");
            }
            string completePath = @$"{_filePath}trips\trip_{tripToCreate.Id}.txt";
            using (StreamWriter sw = new(completePath))
            {
                sw.WriteLine(tripToCreate.Id);
                sw.WriteLine(tripToCreate.Origin);
                sw.WriteLine(tripToCreate.Destination);
                sw.WriteLine(tripToCreate.DepartureTime);
                sw.WriteLine(tripToCreate.TrainToDestination.Id);
                foreach (var item in tripToCreate.AllBookings)
                {
                    sw.WriteLine(item.RegisteredCustomer.Name);
                    sw.WriteLine(item.RegisteredCustomer.PhoneNumber);
                }
            }


        }
        public List<Trip> ListTrips()
        {
            string[] filesInDirectory = Directory.GetFiles(@$"{_filePath}trips");
            List<Trip> tripsToReturn = new();
            for (int i = 0; i < filesInDirectory.Length; i++)
            {
                filesInDirectory[i] = Path.GetFileName(filesInDirectory[i]);
                if (filesInDirectory[i].StartsWith("trip_"))
                {
                    using (StreamReader sr = new(@$"{_filePath}\trips\{filesInDirectory[i]}"))
                    {
                        string tripID = sr.ReadLine();
                        string origin = sr.ReadLine();
                        string destination = sr.ReadLine();
                        string departureTime = sr.ReadLine();
                        string TrainId = sr.ReadLine();
                        Trip temp = new(int.Parse(tripID))
                        {
                            Origin = origin,
                            Destination = destination,
                            DepartureTime = departureTime
                        };
                        temp.TrainToDestination = GetTrain(int.Parse(TrainId));
                        List<Booking> bookingList = new();
                        while (!sr.EndOfStream)
                        {
                            Customer customer = new();
                            customer.Name = sr.ReadLine();
                            customer.PhoneNumber = sr.ReadLine();
                            bookingList.Add(new Booking(customer));

                        }
                        temp.AllBookings.AddRange(bookingList);

                        tripsToReturn.Add(temp);
                    }
                }
            }


            return tripsToReturn;
        }
        public void CreateDirectoryFromPath()
        {
            try
            {
                if (!Directory.Exists(_filePath))
                {
                    Directory.CreateDirectory(_filePath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed {e.ToString()}");
            }
        }
        public void AddDefaultTrainsAndTrips()
        {
            CreateTrain(new Train() { RegNumber = "ABC123", MaxCapacity = 2 });
            CreateTrain(new Train() { RegNumber = "CBA321", MaxCapacity = 4 });
            //CreateTrip(new Trip() { Origin = "Orebro", Destination = "Stockholm", DepartureTime = "08:45", TrainToDestination = _trains[0] });
            //CreateTrip(new Trip() { Origin = "Stockholm", Destination = "Orebro", DepartureTime = "12:30", TrainToDestination = _trains[1] });
            //CreateTrip(new Trip() { Origin = "Orebro", Destination = "Gothenburg", DepartureTime = "14:40", TrainToDestination = _trains[1] });
        }
        public Train GetTrain(int id)
        {
            string pathToFind = @$"{_filePath}trains\train_{id}.txt";
            if (File.Exists(pathToFind))
            {
                using (StreamReader sr = new(pathToFind))
                {
                    string TrainId = sr.ReadLine();
                    string RegNr = sr.ReadLine();
                    string MaxCap = sr.ReadLine();
                    Train temp = new(int.Parse(TrainId))
                    {
                        RegNumber = RegNr,
                        MaxCapacity = int.Parse(MaxCap)
                    };
                    return temp;
                }

            }
            else
            {
                throw new Exception();
            }
        }
    }
}
