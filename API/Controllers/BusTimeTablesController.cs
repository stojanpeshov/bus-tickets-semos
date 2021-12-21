using BusinessLogicLayer;
using DataAccessLayer.Authentication;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusTimeTablesController : ControllerBase
    {
        private readonly BusTimeTablesBLL _busTimeTable;
        public BusTimeTablesController(BusTimeTablesBLL busTimeTable)
        {
            _busTimeTable = busTimeTable;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public IEnumerable<BusTimeTables> FilteredBusTimeTables([FromQuery]DateTime? busDepartureTime, [FromQuery]string busStartPointCity, [FromQuery]int? companyId, [FromQuery]DateTime? busArrivalTime)
        {
            return _busTimeTable.GetAllTimeTablesFiltered(busDepartureTime, busStartPointCity, companyId, busArrivalTime);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Insert([FromBody] BusTimeTables busTimeTable)
        {
            _busTimeTable.Insert(busTimeTable);
            return Ok();
        }
    }
}
