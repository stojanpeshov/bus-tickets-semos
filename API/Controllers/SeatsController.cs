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
    public class SeatsController : ControllerBase
    {
        private readonly SeatsBLL _seatsBLL;
        public SeatsController(SeatsBLL seatsBLL)
        {
            _seatsBLL = seatsBLL;
        }

        [HttpGet]
        public IEnumerable<Seats> GetAllSeats()
        {
            return _seatsBLL.GetAllSeats();
        }

        //[HttpGet("{id}")]
        //public Seats GetSeatById (int id)
        //{
        //    return _seatsBLL.GetSeatById(id);
        //}

        // list me all the free/reserved bus seats
        [HttpGet("{id}/{status}")]
        public IEnumerable<Seats> GetSeatsByBus(int id, string status)
        {
            return _seatsBLL.GetSeatsByBus(id, status);
        }

        [HttpPost]
        public IActionResult Index([FromBodyAttribute] Seats seat)
        {
            _seatsBLL.Insert(seat);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBodyAttribute] int id)
        {
            //needs to update the seat status after booking a seat
            Seats seat = new Seats();
            _seatsBLL.Update(seat);
            return Ok();
        }
    }
}
