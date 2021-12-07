using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EntitiesDAL
{
    public class BookingsDAL : IBookingsDAL
    {
        private readonly DatabaseContext _context;
        public BookingsDAL(DatabaseContext context)
        {
            _context = context;
        }

        public List<Bookings> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public Bookings GetBookingById(int id)
        {
            return _context.Bookings.Find(id);
        }

        public void Insert(Bookings booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void Update(Bookings booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public void Delete(Bookings booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }
    }
}
