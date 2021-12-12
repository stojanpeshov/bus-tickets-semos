using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLogicLayer
{
    // pri kopce prebaraj vozni redovi, treba da se izlistaat site avtobuski linii za odreden datum
    // ako e deneshen den da gi lista tie sto se vremenski po prebaruvanjeto
    public class BusTimeTablesBLL : IBusTimeTablesBLL
    {
        private readonly IBusTimeTablesDAL _busTimeTable;
        public BusTimeTablesBLL(IBusTimeTablesDAL busTimeTable)
        {
            _busTimeTable = busTimeTable;
        }

        // fali podesuvanje za datum i da gi vadi tie sto se po prebaruvanje
        public IEnumerable<BusTimeTables> GetAllTimeTables()
        {
            return _busTimeTable.GetAllTimeTables();
        }

        public IEnumerable<BusTimeTables> GetAllTimeTablesFiltered(DateTime? busDepartureTime, string busStartPointCity, int? companyId, DateTime? busArrivalTime)
        {
            List<BusTimeTables> filteredBusTimeTablesList = _busTimeTable.GetAllTimeTables()
                .Where(x => (x.BusDepartureTime == busDepartureTime || busDepartureTime >= DateTime.Now || busDepartureTime == null)
                && (x.BusLane.BusStartPoint.City.CityName == busStartPointCity || busStartPointCity == null)
                && (x.CompanyId == companyId || companyId == null)
                && (x.BusArrivalTime == busArrivalTime || busArrivalTime == null)).ToList();

            return filteredBusTimeTablesList;
        }
    }
}
