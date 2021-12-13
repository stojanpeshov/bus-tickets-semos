using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class CitiesBLL
    {
        private readonly CitiesDAL _city;
        public CitiesBLL(CitiesDAL city)
        {
            _city = city;
        }

        public void Insert(City city)
        {
            _city.Insert(city);
        }

        public void Update(City city)
        {
            _city.Update(city);
        }

        public void Delete(City city)
        {
            _city.Delete(city);
        }
    }
}
