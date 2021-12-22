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
using System.Security.Claims;
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
            ClaimsPrincipal currentUser = this.User;
            string userName = currentUser.FindFirst(ClaimTypes.Name).Value;
            var currentAppUser = _context.Users.Where(x => x.UserName == userName).FirstOrDefault();

            booking.UserId = currentAppUser.Id;
            _bookingBLL.Insert(booking);
            return Ok();
        }
    }
}
