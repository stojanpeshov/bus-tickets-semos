using DataAccessLayer.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using System.Linq;

namespace DataAccessLayer
{
    // methods for the Cities Entity
    public class citiesDAL
    {
        DatabaseContext db = new DatabaseContext();

        // listing all the cities
        public List<Cities> GetAllCities() 
        {
            return db.Cities.ToList();
        }
        // finding a city by id 
        public Cities GetCityById(int id)
        {
            return db.Cities.Find(id);
        }
        // adding a new city
        public void Insert(Cities city)
        {
            db.Cities.Add(city);
            db.SaveChanges();
        }
        // deleting a city
        public void Delete(Cities city)
        {
            db.Cities.Remove(city);
            db.SaveChanges();
        }
        // updating some parameters 
        public void Update(Cities city)
        {
            db.Cities.Update(city);
            db.SaveChanges();
        }
    }
}
