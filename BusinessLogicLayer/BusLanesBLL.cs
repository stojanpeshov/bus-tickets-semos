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

        // start point filtriranje
        public IEnumerable<BusLane> GetAllBusLanesStartingPoints(int? id)
        {
            List<BusLane> allBusLanes = _busLane.GetAllBusLanes().Where(x => x.BusStartPoint.CityId == id).ToList();
            return allBusLanes;
        }

        // ending point filtriranje
        public IEnumerable<BusLane> GetAllBusLanesEndingPoints(int? id)
        {
            List<BusLane> allBusLanes = _busLane.GetAllBusLanes().Where(x => x.BusDestination.CityId == id).ToList();
            return allBusLanes;
        }

        public void Insert(BusLane busLane)
        {
            _busLane.Insert(busLane);
        }

        public void Delete(BusLane busLane)
        {
            _busLane.Delete(busLane);
        }

        public void Update(BusLane busLane)
        {
            _busLane.Update(busLane);
        }

    }
}
