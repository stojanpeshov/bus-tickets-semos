using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.EntitiesDAL
{
    public interface IBusStationsDAL
    {
        void Delete(BusStations busStation);
        List<BusStations> GetAllBusStations();
        BusStations GetBusStationById(int id);
        void Insert(BusStations busStation);
        void Update(BusStations busStation);
    }
}