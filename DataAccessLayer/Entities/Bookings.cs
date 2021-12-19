using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int TimeTableId { get; set; }
        public BusTimeTables TimeTable { get; set; }
        public int SeatId { get; set; }
    }
}
