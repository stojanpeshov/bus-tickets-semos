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
        public string BusLines { get; set; }
        public int? CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual Cities City { get; set; }
    }
}
