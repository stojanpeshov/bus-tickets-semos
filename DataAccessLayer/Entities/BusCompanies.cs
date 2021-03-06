using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class BusCompanies
    {
        [Key]
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public IEnumerable<Buses> Buses { get; set; }  
    }
}
