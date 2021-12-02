using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DataAccessLayer.EntitiesDAL.Tests
{
    public class BusLanesDALIntegrationTests
    {

        [Fact()]
        public void GetAllBusLanes_ShouldReturnAllBusLanes()
        {
            var context = CreateContext();

            // Seed
            var citySkopje = new City()
            {
                CityName = "Skopje"
            };
            var cityOhrid = new City()
            {
                CityName = "Ohrid"
            };

            var expextedBusLaneSkopje = new BusLane()
            {
                City = citySkopje,
                Price = 10
            };
            var expextedBusLaneOhrid = new BusLane()
            {
                City = cityOhrid,
                Price = 15
            };

            context.Cities.Add(citySkopje);
            context.Cities.Add(cityOhrid);
            context.BusLanes.Add(expextedBusLaneSkopje);
            context.BusLanes.Add(expextedBusLaneOhrid);

            context.SaveChanges();

            // Act    
            var busLanesDAL = new BusLanesDAL(context);
            var actualList = busLanesDAL.GetAllBusLanes();

            // Assert
            Assert.Equal(2, actualList.Count);
            var first = actualList[0]; // if sorting works this should be Ohrid
            Assert.Equal(expextedBusLaneOhrid.Price, first.Price);
            Assert.Equal(expextedBusLaneOhrid.City.CityId, first.City.CityId);
            Assert.Equal(expextedBusLaneOhrid.City.CityName, first.City.CityName);

            var second = actualList[1]; // if sorting works this should be Skopje
            Assert.Equal(expextedBusLaneSkopje.Price, second.Price);
            Assert.Equal(expextedBusLaneSkopje.City.CityId, second.City.CityId);
            Assert.Equal(expextedBusLaneSkopje.City.CityName, second.City.CityName);
        }

        [Fact()]
        public void GetBusLanesByIdTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void InsertTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void UpdateTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void DeleteTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        private static DatabaseContext CreateContext()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder() { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlite(connection).Options;

            var context = new DatabaseContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }
    }
}