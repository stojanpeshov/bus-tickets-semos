using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.DataContext;

namespace DataAccessLayer.EntitiesDAL
{
    // methods for the Buses Entity
    public class busesDAL
    {
        DatabaseContext db = new DatabaseContext();

        // listing all the buses
        public List<Buses> GetAllBuses()
        {
            return db.Buses.ToList();
        }
        // finding a bus by id
        public Buses GetBusesById(int id)
        {
            return db.Buses.Find(id);
        }
        // adding a new bus
        public void Insert(Buses bus)
        {
            db.Buses.Add(bus);
        }
        // updating some parameters 
        public void Update(Buses bus)
        {
            db.Buses.Update(bus);
        }
        // deleting a bus
        public void Delete(Buses bus)
        {
            db.Buses.Remove(bus);
        }
    }
}
