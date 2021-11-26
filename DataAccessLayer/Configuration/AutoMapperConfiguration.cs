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
            CreateMap<BusLanes, Cities>().ForAllMembers(x => x.ExplicitExpansion());
            CreateMap<Cities, BusLanes>().ForAllMembers(x => x.ExplicitExpansion());
        }
    }
}
