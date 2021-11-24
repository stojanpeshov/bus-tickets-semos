using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
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
    }
}
