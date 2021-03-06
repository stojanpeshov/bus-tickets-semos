using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DataAccessLayer.Entities
{
    public class BusLane
    {
        [Key]
        public int LaneId { get; set; }
        public decimal Price { get; set; }
        public int BusId { get; set; }
        public virtual Buses Bus { get; set; }
        public int? BusStartPointId { get; set; }
        public BusStations BusStartPoint { get; set; }
        public int? BusDestinationId { get; set; }
        public BusStations BusDestination { get; set; }
    }
}
