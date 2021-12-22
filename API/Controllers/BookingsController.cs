using BusinessLogicLayer;
using DataAccessLayer.Authentication;
using DataAccessLayer.DataContext;
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
        private readonly DatabaseContext _context;
        public BookingsController (BookingsBLL bookingsBLL, DatabaseContext databaseContext)
        {
            _bookingBLL = bookingsBLL;
            _context = databaseContext;
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Insert ([FromBody]Bookings booking)
        {
            _bookingBLL.Insert(booking);
            return Ok();
        }
        // the column user id should be filled automatically depending on which user is logged in when the booking is made 
    }
}
