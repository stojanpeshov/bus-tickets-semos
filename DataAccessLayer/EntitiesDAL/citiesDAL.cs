using DataAccessLayer.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using System.Linq;

namespace DataAccessLayer
{
    // methods for the Cities Entity
    public class CitiesDAL
    {
        private readonly DatabaseContext _context;
        public CitiesDAL(DatabaseContext context)
        {
            _context = context;
        }

        // listing all the cities
        public List<Cities> GetAllCities() 
        {
            return _context.Cities.ToList();
        }
        // finding a city by id 
        public Cities GetCityById(int id)
        {
            return _context.Cities.Find(id);
        }
        // adding a new city
        public void Insert(Cities city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }
        // deleting a city
        public void Delete(Cities city)
        {
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }
        // updating some parameters 
        public void Update(Cities city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
        }
    }
}
