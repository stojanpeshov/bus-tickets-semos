using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;

namespace BusinessLogicLayer
{
    public class usersBLL
    {
        //private readonly IusersDAL _users;
        //public Users User { get; set; }

        //public usersBLL(usersDAL users)
        //{
        //    _users = users;
        //}
        usersDAL users = new usersDAL();
        public string GetUsernameById(int id)
        {
            Users username = users.GetUserById(id);
            return username.Username;
        }
    }
}
