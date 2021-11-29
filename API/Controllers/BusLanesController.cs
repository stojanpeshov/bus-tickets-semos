﻿using BusinessLogicLayer;
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

        [HttpGet("{id}")]
        public IEnumerable<BusLane> GetAllBusLanesSorted(int id)
        {
            return _busLanesBLL.GetAllBusLanesSorted(id);
        }

        public IActionResult Index([FromBodyAttribute]BusLane busLane)
        {
            _busLanesBLL.Insert(busLane);
            return Ok(busLane);
        }
    }
}
