using System;
using System.Collections.Generic;
using System.Text;
using API.Resources;
using AutoMapper;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Configuration
{
     public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<BusLaneDTO, BusLane>();
            CreateMap<BusLane, BusLaneDTO>();
        }
    }
}
