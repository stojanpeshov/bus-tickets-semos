using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using System.Linq;

namespace DataAccessLayer.EntitiesDAL
{
    public class seatsDAL
    {
        DatabaseContext db = new DatabaseContext();

        // listing all the users
        public List<Seats> GetAllSeats()
        {
            return db.Seats.ToList();
        }
        // finding a user by id
        public Seats GetSeatById(int id)
        {
            return db.Seats.Find(id);
        }
        // adding a new user
        public void Insert(Seats seat)
        {
            db.Seats.Add(seat);
            db.SaveChanges();
        }
        // updating some parameters
        public void Update(Seats seat)
        {
            db.Seats.Update(seat);
            db.SaveChanges();
        }
        // deleting an user
        public void Delete(Seats seat)
        {
            db.Seats.Remove(seat);
            db.SaveChanges();
        }
    }
}
