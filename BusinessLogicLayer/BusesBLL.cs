using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class BusesBLL
    {
        private readonly BusesDAL _bus;
        public BusesBLL (BusesDAL bus)
        {
            _bus = bus;
        }

        public IEnumerable<Buses> GetAllBuses()
        {
            return _bus.GetAllBuses();
        }

        public void Insert (Buses bus)
        {
            _bus.Insert(bus);
        }
    }
}
