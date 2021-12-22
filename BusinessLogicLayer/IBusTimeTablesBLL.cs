using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IBusTimeTablesBLL
    {
        IEnumerable<BusTimeTables> GetAllTimeTables();
        IEnumerable<BusTimeTables> GetAllTimeTablesFiltered(DateTime? busDepartureTime, string busStartPointCity, int? companyId, DateTime? busArrivalTime);
    }
}