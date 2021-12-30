using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.EntitiesDAL
{
    public interface IBusesDAL
    {
        void Delete(Buses bus);
        List<Buses> GetAllBuses();
        Buses GetBusesById(int id);
        void Insert(Buses bus);
        void Update(Buses bus);
    }
}