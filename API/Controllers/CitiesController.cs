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
    public class CitiesController : ControllerBase
    {
        private readonly CitiesBLL _citiesBLL;
        public CitiesController(CitiesBLL citiesBLL)
        {
            _citiesBLL = citiesBLL;
        }

        [HttpPost]
        public IActionResult Index([FromBodyAttribute]City city)
        {
            _citiesBLL.Insert(city);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBodyAttribute]City city)
        {
            _citiesBLL.Update(city);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromBodyAttribute]City city)
        {
            _citiesBLL.Delete(city);
            return Ok();
        }
    }
}
