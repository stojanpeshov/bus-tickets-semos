using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class seatsBLL
    {
        seatsDAL seats = new seatsDAL();
        public IEnumerable<Seats> GetAllSeats()
        {
            return seats.GetAllSeats();
        }
    }
}
