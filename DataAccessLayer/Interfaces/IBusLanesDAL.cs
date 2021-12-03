using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.EntitiesDAL
{
    public interface IBusLanesDAL
    {
        void Delete(BusLane buslane);
        List<BusLane> GetAllBusLanes();
        BusLane GetBusLanesById(int id);
        void Insert(BusLane buslane);
        void Update(BusLane buslane);
    }
}