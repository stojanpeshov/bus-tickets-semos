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
    public class BookingsController : ControllerBase
    {
        private readonly BookingsBLL _bookingBLL;
        public BookingsController (BookingsBLL bookingsBLL)
        {
            _bookingBLL = bookingsBLL;
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Index ([FromBody]Bookings booking)
        {
            _bookingBLL.Insert(booking);
            return Ok();
        }
    }
}
