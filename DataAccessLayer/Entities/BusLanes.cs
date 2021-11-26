using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DataAccessLayer.Entities
{
    public class BusLanes
    {
        [Key]
        public int LaneId { get; set; }
        public decimal Price { get; set; }
        public int? BusId { get; set; }
        [ForeignKey("BusId")]
        public virtual Buses Bus { get; set; }
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual Cities City { get; set; }
    }
}
