using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EntitiesDAL
{
    public class busLanesDAL
    {
        DatabaseContext db = new DatabaseContext();

        public List<BusLanes> GetAllBusLanes()
        {
            return db.BusLanes.ToList();
        }

        public BusLanes GetBusLanesById(int id)
        {
            return db.BusLanes.Find(id);
        }

        public void Insert(BusLanes buslane)
        {
            db.BusLanes.Add(buslane);
        }

        public void Update(BusLanes buslane)
        {
            db.BusLanes.Update(buslane);
        }

        public void Delete(BusLanes buslane)
        {
            db.BusLanes.Remove(buslane);
        }
    }
}
