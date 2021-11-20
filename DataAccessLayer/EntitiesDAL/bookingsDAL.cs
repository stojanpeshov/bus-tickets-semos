using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EntitiesDAL
{
    public class bookingsDAL
    {
        DatabaseContext db = new DatabaseContext();

        public List<Bookings> GetAllBookings()
        {
            return db.Bookings.ToList();
        }

        public Bookings GetBookingById(int id)
        {
            return db.Bookings.Find(id);
        }

        public void Insert(Bookings booking)
        {
            db.Bookings.Add(booking);
        }

        public void Update(Bookings booking)
        {
            db.Bookings.Update(booking);
        }

        public void Delete(Bookings booking)
        {
            db.Bookings.Remove(booking);
        }
    }
}
