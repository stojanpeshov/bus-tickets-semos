using API.Resources;
using AutoMapper;
using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusLanesController : ControllerBase
    {
        private readonly BusLanesBLL _busLanesBLL;
        private readonly IMapper _mapper;

        public BusLanesController(BusLanesBLL busLanesBLL, IMapper mapper)
        {
            _busLanesBLL = busLanesBLL;
            _mapper = mapper;
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
        public IActionResult Index([FromBodyAttribute] BusLaneDTO busLaneDTO)
        {
            var busLane = _mapper.Map<BusLaneDTO, BusLane>(busLaneDTO);
            _busLanesBLL.Insert(busLane);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromBodyAttribute] BusLane busLane)
        {
            _busLanesBLL.Delete(busLane);
            return Ok();
        }

        //[HttpPut("{id}")]
        //public IActionResult Index([FromBodyAttribute] BusLane busLane)
        //{
        //    _busLanesBLL.Update(busLane);
        //    return Ok();
        //}
    }
}
