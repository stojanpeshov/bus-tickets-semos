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
        public IEnumerable<BusLane> GetAllBusLanesSorted(int? id)
        {
            List<BusLane> allBusLanes = _busLane.GetAllBusLanes().Where(x => x.CityId == id).ToList();
            return allBusLanes;
 
        }

        public void Insert(BusLane busLane)
        {
            _busLane.Insert(busLane);
        }

    }
}
