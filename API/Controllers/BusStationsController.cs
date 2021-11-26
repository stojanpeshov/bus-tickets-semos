using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusStationsController : ControllerBase
    {
        private readonly BusStationsBLL _busStationsBLL;
        public BusStationsController(BusStationsBLL busStationsBLL)
        {
            _busStationsBLL = busStationsBLL;
        }

        [HttpGet]
        public IEnumerable<BusStations> GetAllBusStations()
        {
            return _busStationsBLL.GetAllBusStations();
        }

        [HttpPost]
        public IActionResult Index([FromBodyAttribute]BusStations busStation)
        {
            _busStationsBLL.Insert(busStation);
            return Ok(busStation);
        }
    }
}
