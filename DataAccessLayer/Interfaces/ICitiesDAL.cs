using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ICitiesDAL
    {
        void Delete(City city);
        List<City> GetAllCities();
        City GetCityById(int id);
        void Insert(City city);
        void Update(City city);
    }
}