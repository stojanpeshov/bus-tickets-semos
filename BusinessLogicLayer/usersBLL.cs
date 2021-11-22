using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;

namespace BusinessLogicLayer
{
    public class UsersBLL
    {
        private readonly UsersDAL _user;
        public UsersBLL(UsersDAL user)
        {
            _user = user;
        }

        public string GetUsernameById(int id)
        {
            Users username = _user.GetUserById(id);
            return username.Username;
        }
    }
}
