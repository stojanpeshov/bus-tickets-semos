using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.DataContext;
using System.Linq;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EntitiesDAL
{
    // methods for the BusStations Entity
    public class BusStationsDAL
    {
        private readonly DatabaseContext _context;
        public BusStationsDAL(DatabaseContext context)
        {
            _context = context;
        }

        // listing all the bus stations
        public List<BusStations> GetAllBusStations()
        {
            return _context.BusStations.ToList();
        }
        // finding a bus station by id
        public BusStations GetBusStationById(int id)
        {
            return _context.BusStations.Find();
        }
        // adding a new bus station
        public void Insert(BusStations busStation)
        {
            _context.BusStations.Add(busStation);
            _context.SaveChanges();
        }
        // updating some parameters 
        public void Update(BusStations busStation)
        {
            _context.BusStations.Update(busStation);
            _context.SaveChanges();
        }
        // deleting a bus station
        public void Delete(BusStations busStation)
        {
            _context.BusStations.Remove(busStation);
            _context.SaveChanges();
        }
    }
}
