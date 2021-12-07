using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.EntitiesDAL
{
    public interface IBusTimeTablesDAL
    {
        void Delete(BusTimeTables timeTable);
        List<BusTimeTables> GetAllTimeTables();
        BusTimeTables GetTimeTableById(int id);
        void Insert(BusTimeTables timeTable);
        void Update(BusTimeTables timeTable);
    }
}