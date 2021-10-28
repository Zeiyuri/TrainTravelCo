using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCoNew.Data;
using TrainTravelCoNew.Models;

namespace TrainTravelCoNew.Managers
{
    public class TrainManager
    {
        public void CreateTrain(Train trainToCreate)
        {
            DataStorage.Instance.CreateTrain(trainToCreate);
        }
        public List<Train> ListTrains()
        {
            return DataStorage.Instance.ListTrains();
        }
    }
}
