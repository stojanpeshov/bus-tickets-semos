using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class BusTimeTables
    {
        [Key]
        public int TimeTableId { get; set; }
        //public DateTime Date { get; set; }
        public DateTime BusDepartureTime { get; set; }
        public DateTime BusArrivalTime { get; set; }
        public int CompanyId { get; set; }
        public virtual BusCompanies Company { get; set; }
        public BusLane BusLane { get; set; }
    }
}
