using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Seats> GetSeatsByBus(int id)
        {
            List<Seats> freeSeats = _seat.GetAllSeats().Where(x => x.BusId == id && x.Status == "free").ToList();
            return freeSeats;
        }

        public Seats GetSeatById(int id)
        {
            Seats seat = _seat.GetSeatById(id);
            return seat;
        }
    }
}
