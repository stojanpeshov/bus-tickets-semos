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

        public void Insert(Seats seat)
        {
            _seat.Insert(seat);
        }

        public void Update(Seats seat)
        {
            _seat.Update(seat);
        }

        public IEnumerable<Seats> GetSeatsByBus(int id, string status)
        {
            if (status == "free")
            {
                List<Seats> freeSeats = _seat.GetAllSeats().Where(x => x.BusId == id && x.Status == "free").ToList();
                return freeSeats;
            }
            else if (status == "reserved")
            {
                List<Seats> reservedSeats = _seat.GetAllSeats().Where(x => x.BusId == id && x.Status == "reserved").ToList();
                return reservedSeats;
            }
            else
            {
                return null;
            }
        }

        public Seats GetSeatById(int id)
        {
            Seats seat = _seat.GetSeatById(id);
            return seat;
        }

        public void UpdateSeatStatus(int id, string status)
        {
            Seats seat = _seat.GetSeatById(id);

            seat.Status = status;
            _seat.Update(seat);
        }
    }
}
