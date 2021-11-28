using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Configuration
{
     public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<BusLane, City>().ForAllMembers(x => x.ExplicitExpansion());
            CreateMap<City, BusLane>().ForAllMembers(x => x.ExplicitExpansion());
        }
    }
}
