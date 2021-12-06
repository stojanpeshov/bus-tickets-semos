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
    public class BusLanesController : ControllerBase
    {
        private readonly BusLanesBLL _busLanesBLL;

        public BusLanesController (BusLanesBLL busLanesBLL)
        {
            _busLanesBLL = busLanesBLL;
        }

        //this method lists all the bus lanes ordered by city name
        [HttpGet]
        public IEnumerable<BusLane> GetAll()
        {
            return _busLanesBLL.GetAllBusLanes();
        }

        //this method lists all the bus lanes ordered by the city id
        [HttpGet("starting-point/{id}")]
        public IEnumerable<BusLane> GetAllBusLanesByStartingPoint(int id)
        {
            return _busLanesBLL.GetAllBusLanesStartingPoints(id);
        }

        [HttpGet("ending-point/{id}")]
        public IEnumerable<BusLane> GetAllBusLanesByEndingPoint(int id)
        {
            return _busLanesBLL.GetAllBusLanesEndingPoints(id);
        }

        [HttpPost]
        public IActionResult Index([FromBodyAttribute]BusLane busLane)
        {
            _busLanesBLL.Insert(busLane);
            return Ok();
        }
    }
}
