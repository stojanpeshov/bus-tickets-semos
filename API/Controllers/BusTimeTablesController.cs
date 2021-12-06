using BusinessLogicLayer;
using DataAccessLayer.Entities;
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
    public class BusTimeTablesController : ControllerBase
    {
        private readonly BusTimeTablesBLL _busTimeTable;
        public BusTimeTablesController(BusTimeTablesBLL busTimeTable)
        {
            _busTimeTable = busTimeTable;
        }

        [HttpGet/*("{busDepartureTime}/{busStartPointCity}/{companyId}/{busArrivalTime}")*/]
        public IEnumerable<BusTimeTables> FilteredBusTimeTables([FromQuery]DateTime? busDepartureTime, string busStartPointCity, int? companyId, DateTime? busArrivalTime)
        {
            return _busTimeTable.GetAllTimeTablesFiltered(busDepartureTime, busStartPointCity, companyId, busArrivalTime);
        }
    }
}
