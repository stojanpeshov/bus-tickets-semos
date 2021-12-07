using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class BookingsBLL
    {
        private readonly BookingsDAL _booking;
        public BookingsBLL(BookingsDAL booking)
        {
            _booking = booking;
        }

        public void Insert (Bookings booking)
        {
            _booking.Insert(booking);
        }

        public void PurchaseTicket(Bookings booking)
        {
            _booking.Insert(booking);
        }
    }
}
