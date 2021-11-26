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
        //fali get za GetSeatById
    }
}
