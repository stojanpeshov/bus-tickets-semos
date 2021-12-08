using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.DataContext;

namespace DataAccessLayer.EntitiesDAL
{
    // methods for the Buses Entity
    public class BusesDAL : IBusesDAL
    {
        private readonly DatabaseContext _context;
        public BusesDAL(DatabaseContext context)
        {
            _context = context;
        }

        // listing all the buses
        public List<Buses> GetAllBuses()
        {
            return _context.Buses.ToList();
        }
        // finding a bus by id
        public Buses GetBusesById(int id)
        {
            return _context.Buses.Find(id);
        }
        // adding a new bus
        public void Insert(Buses bus)
        {
            _context.Buses.Add(bus);
            _context.SaveChanges();
            int busCapacity = bus.BusCapacity;
            for (int i = 1; i <= busCapacity; i++)
            {
                Seats seats = new Seats();

                seats.SeatNumber = i;
                seats.BusId = bus.BusId;
                seats.Status = "free";
                _context.Seats.Add(seats);
                _context.SaveChanges();
            }
            _context.SaveChanges();
        }
        // updating some parameters 
        public void Update(Buses bus)
        {
            _context.Buses.Update(bus);
            _context.SaveChanges();
        }
        // deleting a bus
        public void Delete(Buses bus)
        {
            _context.Buses.Remove(bus);
            _context.SaveChanges();
        }
    }
}
