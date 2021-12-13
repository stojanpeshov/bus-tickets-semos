using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Resources
{
    public class BusLaneDTO
    {
        public int LaneId { get; set; }
        public decimal Price { get; set; }
        public int BusId { get; set; }
        public virtual Buses Bus { get; set; }
        public int BusStartPointId { get; set; }
        public int BusDestinationId { get; set; }
    }
}
