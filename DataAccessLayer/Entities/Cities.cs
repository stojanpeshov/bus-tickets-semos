﻿using System;
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
    }
}
