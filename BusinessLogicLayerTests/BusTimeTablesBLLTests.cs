using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace BusinessLogicLayer.Tests
{
    public class BusTimeTablesBLLTests
    {
        [Fact()]
        public void GetAllTimeTablesFiltered_By_StartPointCity()
        {
            var context = CreateContext();
            var dal = new BusTimeTablesDAL(context);

            // Seed
            City citySkopje;
            BusCompanies company1;
            var timeTables = SeedData(dal, out citySkopje, out company1);

            var bll = new BusTimeTablesBLL(dal);
            var actualList = bll.GetAllTimeTablesFiltered(
                busDepartureTime: null,
                busStartPointCity: citySkopje.CityName,
                companyId: null,
                busArrivalTime: null
                ).ToList();

            Assert.Equal(4, actualList.Count);
            var first = actualList[0]; 
            var timeTable1 = timeTables[0];
            AssertTimeTable(timeTable1, first);

            var second = actualList[1];
            var timeTable2 = timeTables[1];
            AssertTimeTable(timeTable2, second);

            var third = actualList[2];
            var dayBeforeTimeTable = timeTables[3];
            AssertTimeTable(dayBeforeTimeTable, third);

            var fourth = actualList[3];
            var pastTimeTodayTable2 = timeTables[4];
            AssertTimeTable(pastTimeTodayTable2, fourth);
        }

        [Fact()]
        public void GetAllTimeTablesFiltered_By_StartPointCity_And_Company()
        {
            var context = CreateContext();
            var dal = new BusTimeTablesDAL(context);

            // Seed
            City citySkopje;
            BusCompanies company1;
            var timeTables = SeedData(dal, out citySkopje, out company1);

            var bll = new BusTimeTablesBLL(dal);
            var actualList = bll.GetAllTimeTablesFiltered(
                busDepartureTime: null,
                busStartPointCity: citySkopje.CityName,
                companyId: company1.CompanyId,
                busArrivalTime: null
                ).ToList();

            Assert.Equal(3, actualList.Count);
            var first = actualList[0];
            var timeTable1 = timeTables[0];
            AssertTimeTable(timeTable1, first);

            var second = actualList[1];
            var dayBeforeTimeTable = timeTables[3];
            AssertTimeTable(dayBeforeTimeTable, second);

            var third = actualList[2];
            var pastTimeTodayTable2 = timeTables[4];
            AssertTimeTable(pastTimeTodayTable2, third);
        }

        [Fact()]
        public void GetAllTimeTablesFiltered_By_StartPointCity_And_DepartureTime()
        {
            var context = CreateContext();
            var dal = new BusTimeTablesDAL(context);

            // Seed
            City citySkopje;
            BusCompanies company1;
            var timeTables = SeedData(dal, out citySkopje, out company1);

            var bll = new BusTimeTablesBLL(dal);
            var actualList = bll.GetAllTimeTablesFiltered(
                busDepartureTime: DateTime.Now.AddHours(1),
                busStartPointCity: citySkopje.CityName,
                companyId: null,
                busArrivalTime: null
                ).ToList();

            Assert.Equal(2, actualList.Count);
            var first = actualList[0]; // if sorting works this should be Ohrid
            var timeTable1 = timeTables[0];
            AssertTimeTable(first, timeTable1);

            var second = actualList[1]; // if sorting works this should be Ohrid
            var timeTable2 = timeTables[1];
            AssertTimeTable(second, timeTable2);
        }


        private static BusTimeTables[] SeedData(BusTimeTablesDAL dal, out City citySkopje, out BusCompanies company1)
        {
            citySkopje = new City()
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

            company1 = new BusCompanies() { Company = "company 1" };
            var company2 = new BusCompanies() { Company = "company 2" };

            var timeTable1 = new BusTimeTables()
            {
                BusDepartureTime = DateTime.Now.AddDays(1),
                BusArrivalTime = DateTime.Now.AddDays(2),
                Company = company1,
                BusLane = expectedSkopjeOhrid
            };
            var timeTable2 = new BusTimeTables()
            {
                BusDepartureTime = DateTime.Now.AddDays(1).AddHours(2),
                BusArrivalTime = DateTime.Now.AddDays(2),
                Company = company2,
                BusLane = expectedSkopjeOhrid
            };
            var timeTable3 = new BusTimeTables()
            {
                BusDepartureTime = DateTime.Now.AddDays(2).AddHours(1),
                BusArrivalTime = DateTime.Now.AddDays(3),
                Company = company1,
                BusLane = expectedOhridSkopje
            };

            var dayBeforeTimeTable = new BusTimeTables()
            {
                BusDepartureTime = DateTime.Now.AddDays(-2),
                BusArrivalTime = DateTime.Now.AddDays(-1),
                Company = company1,
                BusLane = expectedSkopjeOhrid
            };
            var pastTimeTodayTable2 = new BusTimeTables()
            {
                BusDepartureTime = DateTime.Now.AddHours(-3),
                BusArrivalTime = DateTime.Now.AddHours(2),
                Company = company1,
                BusLane = expectedSkopjeOhrid
            };

            dal.Insert(timeTable1);
            dal.Insert(timeTable2);
            dal.Insert(timeTable3);
            dal.Insert(dayBeforeTimeTable);
            dal.Insert(pastTimeTodayTable2);

            return new BusTimeTables[] { timeTable1, timeTable2, timeTable3, dayBeforeTimeTable, pastTimeTodayTable2 };
        }

        private static void AssertTimeTable(BusTimeTables expected, BusTimeTables actual)
        {
            Assert.Equal(expected.BusDepartureTime, actual.BusDepartureTime);
            Assert.Equal(expected.BusArrivalTime, actual.BusArrivalTime);
            Assert.Equal(expected.Company, actual.Company);
            Assert.Equal(expected.BusLane.BusStartPoint.City.CityId, actual.BusLane.BusStartPoint.City.CityId);
            Assert.Equal(expected.BusLane.BusStartPoint.City.CityName, actual.BusLane.BusStartPoint.City.CityName);
            Assert.Equal(expected.BusLane.BusDestination.CityId, actual.BusLane.BusDestination.CityId);
            Assert.Equal(expected.BusLane.BusDestination.City.CityName, actual.BusLane.BusDestination.City.CityName);
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