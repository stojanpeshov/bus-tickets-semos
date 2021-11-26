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

        [HttpGet]
        public IEnumerable<BusLanes> GetAllBusLanes()
        {
            return _busLanesBLL.GetAllBusLanes();
        }

        public IActionResult Index([FromBodyAttribute]BusLanes busLane)
        {
            _busLanesBLL.Insert(busLane);
            return Ok(busLane);
        }
    }
}
