using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;
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

        // fali filtriranje spored naziv na bus lane ili grad vo koj pripagja
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
