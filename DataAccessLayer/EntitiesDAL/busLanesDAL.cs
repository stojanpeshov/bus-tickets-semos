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

        public List<BusLanes> GetAllBusLanes()
        {
            return _context.BusLanes.ToList();
        }

        public BusLanes GetBusLanesById(int id)
        {
            return _context.BusLanes.Find(id);
        }

        public void Insert(BusLanes buslane)
        {
            _context.BusLanes.Add(buslane);
        }

        public void Update(BusLanes buslane)
        {
            _context.BusLanes.Update(buslane);
        }

        public void Delete(BusLanes buslane)
        {
            _context.BusLanes.Remove(buslane);
        }
    }
}
