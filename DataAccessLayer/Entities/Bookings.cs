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
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
        public int? TimeTableId { get; set; }
        [ForeignKey("TimeTableId")]
        public virtual BusTimeTables TimeTable { get; set; }
        public int? LaneId { get; set; }
        [ForeignKey("LaneId")]
        public  virtual BusLane Lane { get; set; }
        public int BusId { get; set; }
        [ForeignKey("BusId")]
        public virtual Buses Bus { get; set; }
    }
}
