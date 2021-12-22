using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Seats
    {
        [Key]
        public int SeatId { get; set; }
        public int SeatNumber { get; set; }
        public int BusId { get; set; }
        public virtual Buses Bus { get; set; }
        public string Status { get; set; }
    }
}
