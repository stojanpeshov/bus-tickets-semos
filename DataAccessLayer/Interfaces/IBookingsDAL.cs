using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.EntitiesDAL
{
    public interface IBookingsDAL
    {
        void Delete(Bookings booking);
        List<Bookings> GetAllBookings();
        Bookings GetBookingById(int id);
        void Insert(Bookings booking);
        void Update(Bookings booking);
    }
}