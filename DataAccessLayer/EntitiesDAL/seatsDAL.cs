using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using System.Linq;

namespace DataAccessLayer.EntitiesDAL
{
    public class SeatsDAL : ISeatsDAL
    {
        private readonly DatabaseContext _context;
        public SeatsDAL(DatabaseContext context)
        {
            _context = context;
        }

        // listing all the users
        public List<Seats> GetAllSeats()
        {
            return _context.Seats.ToList();
        }
        // finding a user by id
        public Seats GetSeatById(int id)
        {
            return _context.Seats.Find(id);
        }
        // adding a new user
        public void Insert(Seats seat)
        {
            _context.Seats.Add(seat);
            _context.SaveChanges();
        }
        // updating some parameters
        public void Update(Seats seat)
        {
            _context.Seats.Update(seat);
            _context.SaveChanges();
        }
        // deleting an user
        public void Delete(Seats seat)
        {
            _context.Seats.Remove(seat);
            _context.SaveChanges();
        }
    }
}
