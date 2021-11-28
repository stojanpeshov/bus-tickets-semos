using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class BusLanesBLL
    {
        private readonly BusLanesDAL _busLane;
        public BusLanesBLL(BusLanesDAL busLane)
        {
            _busLane = busLane;
        }

        public IEnumerable<BusLane> GetAllBusLanes()
        {
            return _busLane.GetAllBusLanes();
        }

        // filtriranje spored gradovi na avtobuski linii
        // bara instanciranje na nova referenca(object reference not set..)
        public IEnumerable<BusLane> GetAllBusLanesSorted()
        {
            //return _busLane.GetAllBusLanes().OrderBy(x => x.City.CityName);
            foreach (var lane in _busLane.GetAllBusLanes())
            {
                Debug.WriteLine(lane.City);
            }
            return _busLane.GetAllBusLanes().OrderBy(x => x.City.CityName);
        }

        public void Insert(BusLane busLane)
        {
            _busLane.Insert(busLane);
        }

    }
}
