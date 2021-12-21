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
    public class SeatsController : ControllerBase
    {
        private readonly SeatsBLL _seatsBLL;
        public SeatsController(SeatsBLL seatsBLL)
        {
            _seatsBLL = seatsBLL;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
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
        [Authorize(Roles = "User, Admin")]
        public IEnumerable<Seats> GetSeatsByBus(int id, string status)
        {
            return _seatsBLL.GetSeatsByBus(id, status);
        }

        // insert new seat
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Insert([FromBody] Seats seat)
        {
            _seatsBLL.Insert(seat);
            return Ok();
        }

        // update seat status
        [HttpPut("{id}/{status}")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Update(int id, string status)
        {
            if (status.ToLower() == "free" || status.ToLower() == "reserved")
            {
                _seatsBLL.UpdateSeatStatus(id, status);
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
