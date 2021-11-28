using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EntitiesDAL
{
    public class BusLanesDAL
    {
        private readonly DatabaseContext _context;
        public BusLanesDAL (DatabaseContext context)
        {
            _context = context;
        }

        public List<BusLane> GetAllBusLanes()
        {
            return _context.BusLanes.ToList();
        }

        public BusLane GetBusLanesById(int id)
        {
            return _context.BusLanes.Find(id);
        }

        public void Insert(BusLane buslane)
        {
            _context.BusLanes.Add(buslane);
        }

        public void Update(BusLane buslane)
        {
            _context.BusLanes.Update(buslane);
        }

        public void Delete(BusLane buslane)
        {
            _context.BusLanes.Remove(buslane);
        }
    }
}
