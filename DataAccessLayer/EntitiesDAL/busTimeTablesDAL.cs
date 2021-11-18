using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EntitiesDAL
{
    public class busTimeTablesDAL
    {
        DatabaseContext db = new DatabaseContext();

        public List<BusTimeTables> GetAllTimeTables()
        {
            return db.BusTimeTables.ToList();
        }

        public BusTimeTables GetTimeTableById(int id)
        {
            return db.BusTimeTables.Find(id);
        }

        public void Insert (BusTimeTables timeTable)
        {
            db.BusTimeTables.Add(timeTable);
        }

        public void Update (BusTimeTables timeTable)
        {
            db.BusTimeTables.Update(timeTable);
        }

        public void Delete (BusTimeTables timeTable)
        {
            db.BusTimeTables.Remove(timeTable);
        }
    }
}
