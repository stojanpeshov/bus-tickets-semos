using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Buses
    {
        [Key]
        public int BusId { get; set; }
        public string BusType { get; set; }
        public int BusCapacity { get; set; }
        //public IEnumerable<Seats> Seats { get; set; }
        public int CompanyId { get; set; }
        public BusCompanies Company { get; set; }
    }
}
