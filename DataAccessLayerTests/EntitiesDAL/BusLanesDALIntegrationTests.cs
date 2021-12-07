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
            //context.Cities.Add(citySkopje);
            //context.Cities.Add(cityOhrid);

            var busStationSkopje = new BusStations()
            {
                City = citySkopje
            };
            var busStationOhrid = new BusStations()
            {
                City = cityOhrid
            };
            //context.BusStations.Add(busStationSkopje);
            //context.BusStations.Add(busStationOhrid);

            var bus = new Buses()
            {
                BusCapacity = 15,
                BusType = "type",
                Company = new BusCompanies() { Company = "company" }
            };

            var expectedSkopjeOhrid = new BusLane()
            {
                Bus = bus,
                BusStartPoint = busStationSkopje,
                BusDestination = busStationOhrid,
                Price = 10
            };
            var expectedOhridSkopje = new BusLane()
            {
                Bus = bus,
                BusStartPoint = busStationOhrid,
                BusDestination = busStationSkopje,
                Price = 15
            };
            context.BusLanes.Add(expectedSkopjeOhrid);
            context.BusLanes.Add(expectedOhridSkopje);
            context.SaveChanges();

            // Act    
            var busLanesDAL = new BusLanesDAL(context);
            var actualList = busLanesDAL.GetAllBusLanes();

            // Assert
            Assert.Equal(2, actualList.Count);
            var first = actualList[0]; // if sorting works this should be Ohrid - Skopje
            Assert.Equal(expectedOhridSkopje.Price, first.Price);
            Assert.Equal(expectedOhridSkopje.BusStartPoint.CityId, first.BusStartPoint.CityId);
            Assert.Equal(expectedOhridSkopje.BusStartPoint.City.CityName, first.BusStartPoint.City.CityName);
            Assert.Equal(expectedOhridSkopje.BusDestination.CityId, first.BusDestination.CityId);
            Assert.Equal(expectedOhridSkopje.BusDestination.City.CityName, first.BusDestination.City.CityName);

            var second = actualList[1]; // if sorting works this should be Skopje - Ohrid
            Assert.Equal(expectedSkopjeOhrid.Price, second.Price);
            Assert.Equal(expectedSkopjeOhrid.BusStartPoint.CityId, second.BusStartPoint.CityId);
            Assert.Equal(expectedSkopjeOhrid.BusStartPoint.City.CityName, second.BusStartPoint.City.CityName);
            Assert.Equal(expectedSkopjeOhrid.BusDestination.CityId, second.BusDestination.CityId);
            Assert.Equal(expectedSkopjeOhrid.BusDestination.City.CityName, second.BusDestination.City.CityName);
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