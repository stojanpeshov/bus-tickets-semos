using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntitiesDAL
{
    public interface IUsersDAL
    {
        List<Users> GetAllUsers();
        Users GetUserById(int id);
        void Insert(Users user);
        void Update(Users user);
        void Delete(Users user);
    }
}
