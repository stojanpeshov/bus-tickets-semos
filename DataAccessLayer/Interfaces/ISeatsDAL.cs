using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.EntitiesDAL
{
    public interface ISeatsDAL
    {
        void Delete(Seats seat);
        List<Seats> GetAllSeats();
        Seats GetSeatById(int id);
        void Insert(Seats seat);
        void Update(Seats seat);
    }
}