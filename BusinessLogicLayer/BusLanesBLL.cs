using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;
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

        // filtriranje spored gradovi na avtobuski linii
        // bara instanciranje na nova referenca(object reference not set..)
        public IEnumerable<BusLanes> GetAllBusLanesSorted()
        {
            return _busLane.GetAllBusLanes().OrderBy(x => x.City.CityName);
        }

        public IEnumerable<BusLanes> GetAllBusLanes()
        {
            return _busLane.GetAllBusLanes();
        }

        public void Insert(BusLanes busLane)
        {
            _busLane.Insert(busLane);
        }

    }
}
