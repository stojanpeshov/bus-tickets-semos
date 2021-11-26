using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class BusStationsBLL
    {
        private readonly BusStationsDAL _busStation;
        public BusStationsBLL(BusStationsDAL busStation)
        {
            _busStation = busStation;
        }

        public IEnumerable<BusStations> GetAllBusStations()
        {
            return _busStation.GetAllBusStations();
        }

        public void Insert(BusStations busStation)
        {
            _busStation.Insert(busStation);
        }
    }
}
