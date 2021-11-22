using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using System.Linq;
using DataAccessLayer.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntitiesDAL
{
    // methods for the Users Entity
    public class UsersDAL : IUsersDAL

    {
        private readonly DatabaseContext _context;
        public UsersDAL (DatabaseContext context)
        {
            _context = context;
        }

        // listing all the users
        public List<Users> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        // finding a user by id
        public Users GetUserById(int id)
        {
            return _context.Users.Find(id);
        }
        // adding a new user
        public void Insert(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        // updating some parameters
        public void Update(Users user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        // deleting an user
        public void Delete(Users user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
