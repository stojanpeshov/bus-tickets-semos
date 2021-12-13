using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IBusLanesBLL
    {
        void Delete(BusLane busLane);
        IEnumerable<BusLane> GetAllBusLanes();
        IEnumerable<BusLane> GetAllBusLanesEndingPoints(int? id);
        IEnumerable<BusLane> GetAllBusLanesStartingPoints(int? id);
        void Insert(BusLane busLane);
        void Update(BusLane busLane);
    }
}