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
    public class BusCompaniesController : ControllerBase
    {
        private readonly BusCompaniesBLL _busCompaniesBLL;
        public BusCompaniesController (BusCompaniesBLL busCompaniesBLL)
        {
            _busCompaniesBLL = busCompaniesBLL;
        }

        [HttpGet]
        public IEnumerable<BusCompanies> GetAllBusCompanies()
        {
            return _busCompaniesBLL.GetAllBusCompanies();
        }

        [HttpPost]
        public IActionResult Index([FromBody] BusCompanies busCompany)
        {
            _busCompaniesBLL.Insert(busCompany);
            return Ok(busCompany);
        }
    }
}
