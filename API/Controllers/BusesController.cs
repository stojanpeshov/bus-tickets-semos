using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly BusesDAL _busesDAL;
        public BusesController(BusesDAL busesDAL)
        {
            _busesDAL = busesDAL;
        }

        [HttpGet]
        public IEnumerable<Buses> GetAllBuses()
        {
            return _busesDAL.GetAllBuses();
        }
    }
}
