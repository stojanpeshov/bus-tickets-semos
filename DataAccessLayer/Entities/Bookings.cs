using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using API.Authentication;

namespace DataAccessLayer.Entities
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int TimeTableId { get; set; }
        public BusTimeTables TimeTable { get; set; }
        public int SeatId { get; set; }
        public virtual Seats Seat { get; set; }
    }
}
