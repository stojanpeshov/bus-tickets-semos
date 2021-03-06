using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccessLayer.Entities
{
    public class BusStations
    {
        [Key]
        public int StationId { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
