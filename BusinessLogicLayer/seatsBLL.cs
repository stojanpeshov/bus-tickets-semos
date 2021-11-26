using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    // da postoi opcija za izbor na broj na sediste i da gi prikazuva samo tie sto ne se rezervirani
    public class SeatsBLL
    {
        private readonly SeatsDAL _seat;
        public SeatsBLL(SeatsDAL seat)
        {
            _seat = seat;
        }

        public IEnumerable<Seats> GetAllSeats()
        {
            return _seat.GetAllSeats();
        }

        public string GetSeatById(int id)
        {
            Seats seat = _seat.GetSeatById(id);
            return seat.SeatNumber.ToString();
        }
    }
}
