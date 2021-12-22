using DataAccessLayer.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using System.Linq;

namespace DataAccessLayer
{
    // methods for the Cities Entity
    public class CitiesDAL : ICitiesDAL
    {
        private readonly DatabaseContext _context;
        public CitiesDAL(DatabaseContext context)
        {
            _context = context;
        }

        // listing all the cities
        public List<City> GetAllCities()
        {
            return _context.Cities.ToList();
        }
        // finding a city by id 
        public City GetCityById(int id)
        {
            return _context.Cities.Find(id);
        }
        // adding a new city
        public void Insert(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }
        // deleting a city
        public void Delete(City city)
        {
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }
        // updating some parameters 
        public void Update(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
        }
    }
}
