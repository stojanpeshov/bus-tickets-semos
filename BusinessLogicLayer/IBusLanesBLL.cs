using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IBusLanesBLL
    {
        List<BusLane> GetAllBusLanes();
        IEnumerable<BusLane> GetAllBusLanesSorted(int? cityId);
        void Insert(BusLane busLane);
    }
}