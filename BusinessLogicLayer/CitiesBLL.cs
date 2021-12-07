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
    }
}
