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
    [Route("api/[controller]")]
    [ApiController]
    public class BusCompaniesController : ControllerBase
    {
        private readonly BusCompaniesBLL _busCompaniesBLL;
        public BusCompaniesController (BusCompaniesBLL busCompaniesBLL)
        {
            _busCompaniesBLL = busCompaniesBLL;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public IEnumerable<BusCompanies> GetAllBusCompanies()
        {
            return _busCompaniesBLL.GetAllBusCompanies();
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Insert([FromBody] BusCompanies busCompany)
        {
            _busCompaniesBLL.Insert(busCompany);
            return Ok(busCompany);
        }
    }
}
