using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace BusinessLogicLayer.Tests
{
    public class BusLanesBLLTests
    {

        private readonly BusLanesBLL busLanesService;
        private readonly Mock<IBusLanesDAL> mockBusLanesDAL;
        public BusLanesBLLTests()
        {
            mockBusLanesDAL = new Mock<IBusLanesDAL>();
            busLanesService = new BusLanesBLL(mockBusLanesDAL.Object);
        }

        [Fact()]
        public void GetAllBusLanes_ShouldReturnAllBusLanes()
        {
            // Seed
            var citySkopje = new City()
            {
                CityName = "Skopje"
            };
            var cityOhrid = new City()
            {
                CityName = "Ohrid"
            };

            var busStationSkopje = new BusStations()
            {
                City = citySkopje
            };
            var busStationOhrid = new BusStations()
            {
                City = cityOhrid
            };

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

            var expectedLanes = new List<BusLane> { expectedOhridSkopje, expectedSkopjeOhrid };
            
            // Mock
            mockBusLanesDAL.Setup(x => x.GetAllBusLanes()).Returns(expectedLanes);

            // Act
            var actualList = busLanesService.GetAllBusLanes();

            // Assert
            Assert.Equal(2, actualList.Count);
            var first = actualList[0]; // if sorting works this should be Ohrid
            Assert.Equal(expectedOhridSkopje.Price, first.Price);
            Assert.Equal(expectedOhridSkopje.BusStartPoint.CityId, first.BusStartPoint.CityId);
            Assert.Equal(expectedOhridSkopje.BusStartPoint.City.CityName, first.BusStartPoint.City.CityName);
            Assert.Equal(expectedOhridSkopje.BusDestination.CityId, first.BusDestination.CityId);
            Assert.Equal(expectedOhridSkopje.BusDestination.City.CityName, first.BusDestination.City.CityName);

            var second = actualList[1]; // if sorting works this should be Skopje
            Assert.Equal(expectedSkopjeOhrid.Price, second.Price);
            Assert.Equal(expectedSkopjeOhrid.BusStartPoint.CityId, second.BusStartPoint.CityId);
            Assert.Equal(expectedSkopjeOhrid.BusStartPoint.City.CityName, second.BusStartPoint.City.CityName);
            Assert.Equal(expectedSkopjeOhrid.BusDestination.CityId, second.BusDestination.CityId);
            Assert.Equal(expectedSkopjeOhrid.BusDestination.City.CityName, second.BusDestination.City.CityName);
        }

        [Fact()]
        public void GetAllBusLanesSortedTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void InsertTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}