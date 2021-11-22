using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EntitiesDAL
{
    public class BusTimeTablesDAL
    {
        private readonly DatabaseContext _context;
        public BusTimeTablesDAL(DatabaseContext context)
        {
            _context = context;
        }

        public List<BusTimeTables> GetAllTimeTables()
        {
            return _context.BusTimeTables.ToList();
        }

        public BusTimeTables GetTimeTableById(int id)
        {
            return _context.BusTimeTables.Find(id);
        }

        public void Insert (BusTimeTables timeTable)
        {
            _context.BusTimeTables.Add(timeTable);
        }

        public void Update (BusTimeTables timeTable)
        {
            _context.BusTimeTables.Update(timeTable);
        }

        public void Delete (BusTimeTables timeTable)
        {
            _context.BusTimeTables.Remove(timeTable);
        }
    }
}
