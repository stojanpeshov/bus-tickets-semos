using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Cities
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        //public IEnumerable<BusLanes> BusLanes { get; set; }
        public int? BusLanesId { get; set; }
        //public virtual BusLanes BusLanes { get; set; }

        // dali ima greska vo entitetot ili vo metodot?
    }
}
