using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    // pri kopce prebaraj vozni redovi, treba da se izlistaat site avtobuski linii za odreden datum
    // ako e deneshen den da gi lista tie sto se vremenski po prebaruvanjeto
    public class BusTimeTablesBLL
    {
        private readonly BusLanesDAL _busLanes;
        public BusTimeTablesBLL(BusLanesDAL busTimeTable)
        {
            _busLanes = busTimeTable;
        }

        // fali podesuvanje za datum i da gi vadi tie sto se po prebaruvanje
        public IEnumerable<BusLanes> GetAllBusLanes()
        {
            return _busLanes.GetAllBusLanes();
        }

    }
}
