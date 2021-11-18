using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class BusTimeTables
    {
        [Key]
        public int TimeTableId { get; set; }
        public string BusStartPoint { get; set; }
        public DateTime Date { get; set; }
        public string BusDestination { get; set; }
        public DateTime BusDepartureTime { get; set; }
        public DateTime BusArrivalTime { get; set; }

    }
}
