using BusinessLogicLayer;
using DataAccessLayer.Authentication;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "User, Admin")]
        public IEnumerable<BusStations> GetAllBusStations()
        {
            return _busStationsBLL.GetAllBusStations();
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Insert([FromBody]BusStations busStation)
        {
            _busStationsBLL.Insert(busStation);
            return Ok(busStation);
        }
    }
}
