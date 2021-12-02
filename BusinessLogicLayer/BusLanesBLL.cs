using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class BusLanesBLL : IBusLanesBLL
    {
        private readonly IBusLanesDAL _busLane;
        public BusLanesBLL(IBusLanesDAL busLane)
        {
            _busLane = busLane;
        }

        public List<BusLane> GetAllBusLanes()
        {
            return _busLane.GetAllBusLanes();
        }

        // filtriranje spored gradovi na avtobuski linii
        public IEnumerable<BusLane> GetAllBusLanesSorted(int? cityId)
        {
            List<BusLane> allBusLanes = _busLane.GetAllBusLanes().Where(x => x.CityId == cityId).ToList();
            return allBusLanes;

        }

        public void Insert(BusLane busLane)
        {
            _busLane.Insert(busLane);
        }

    }
}
