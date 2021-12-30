using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntitiesDAL
{
    public class BusLanesDAL : IBusLanesDAL
    {
        private readonly DatabaseContext _context;
        public BusLanesDAL(DatabaseContext context)
        {
            _context = context;
        }

        public List<BusLane> GetAllBusLanes()
        {
            /* TODO: 
             * EF Core, by default, does not include related entities to your models when you querying data 
             * because it could be very slow (imagine a model with ten related entities, all all related entities having its own relationships).
             * To include the categories data, we need only one extra line: 
             * .Include(..)
             * 
             * see: https://www.freecodecamp.org/news/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28/
             * 
             * 
             * preporaclivo e da se pravi orderby na nivo na DAL t.e. database query
             * */
            var result = _context.BusLanes
                .Include(bl => bl.BusStartPoint)
                .ThenInclude(bs => bs.City)
                .OrderBy(bl => bl.BusStartPoint.City.CityName)
                .Include(bl => bl.BusDestination)
                .ThenInclude(bs => bs.City)
                .ToList();
            return result;
        }

        public BusLane GetBusLanesById(int id)
        {
            return _context.BusLanes.Find(id);
        }

        public void Insert(BusLane buslane)
        {
            _context.BusLanes.Add(buslane);
            _context.SaveChanges();
        }

        public void Update(BusLane buslane)
        {
            _context.BusLanes.Update(buslane);
            _context.SaveChanges();
        }

        public void Delete(BusLane buslane)
        {
            _context.BusLanes.Remove(buslane);
            _context.SaveChanges();
        }
    }
}
