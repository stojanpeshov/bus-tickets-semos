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
            var citySkopje = new City()
            {
                CityName = "Skopje"
            };
            var cityOhrid = new City()
            {
                CityName = "Ohrid"
            };

            var expectedBusLaneSkopje = new BusLane()
            {
                City = citySkopje,
                Price = 10
            };
            var expectedBusLaneOhrid = new BusLane()
            {
                City = cityOhrid,
                Price = 15
            };

            var expectedLanes = new List<BusLane> { expectedBusLaneOhrid, expectedBusLaneSkopje };
            
            // Mock
            mockBusLanesDAL.Setup(x => x.GetAllBusLanes()).Returns(expectedLanes);

            // Act
            var actualList = busLanesService.GetAllBusLanes();

            // Assert
            Assert.Equal(2, actualList.Count);
            var first = actualList[0]; // if sorting works this should be Ohrid
            Assert.Equal(expectedBusLaneOhrid.Price, first.Price);
            Assert.Equal(expectedBusLaneOhrid.City.CityId, first.City.CityId);
            Assert.Equal(expectedBusLaneOhrid.City.CityName, first.City.CityName);

            var second = actualList[1]; // if sorting works this should be Skopje
            Assert.Equal(expectedBusLaneSkopje.Price, second.Price);
            Assert.Equal(expectedBusLaneSkopje.City.CityId, second.City.CityId);
            Assert.Equal(expectedBusLaneSkopje.City.CityName, second.City.CityName);
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