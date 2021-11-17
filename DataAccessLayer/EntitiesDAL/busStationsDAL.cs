using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.DataContext;
using System.Linq;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EntitiesDAL
{
    // methods for the BusStations Entity
    public class busStationsDAL
    {
        DatabaseContext db = new DatabaseContext();

        // listing all the bus stations
        public List<BusStations> GetAllBusStations()
        {
            return db.BusStations.ToList();
        }
        // finding a bus station by id
        public BusStations GetBusStationById(int id)
        {
            return db.BusStations.Find();
        }
        // adding a new bus station
        public void Insert(BusStations busStation)
        {
            db.BusStations.Add(busStation);
            db.SaveChanges();
        }
        // updating some parameters 
        public void Update(BusStations busStation)
        {
            db.BusStations.Update(busStation);
            db.SaveChanges();
        }
        // deleting a bus station
        public void Delete(BusStations busStation)
        {
            db.BusStations.Remove(busStation);
            db.SaveChanges();
        }
    }
}
