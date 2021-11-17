using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using System.Linq;
using DataAccessLayer.DataContext;

namespace DataAccessLayer.EntitiesDAL
{
    // methods for the Users Entity
    public class usersDAL
    {
        DatabaseContext db = new DatabaseContext();

        // listing all the users
        public List<Users> GetAllUsers()
        {
            return db.Users.ToList();
        }
        // finding a user by id
        public Users GetUserById(int id)
        {
            return db.Users.Find(id);
        }
        // adding a new user
        public void Insert(Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        // updating some parameters
        public void Update(Users user)
        {
            db.Users.Update(user);
            db.SaveChanges();
        }
        // deleting an user
        public void Delete(Users user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
