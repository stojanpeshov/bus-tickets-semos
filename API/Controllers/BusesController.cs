﻿using BusinessLogicLayer;
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
        private readonly BusesBLL _busesBLL;
        public BusesController (BusesBLL busesBLL)
        {
            _busesBLL = busesBLL;
        }

        [HttpGet]
        public IEnumerable<Buses> GetAllBuses()
        {
            return _busesBLL.GetAllBuses();
        }

        [HttpPost]
        public IActionResult Index([FromBodyAttribute] Buses bus)
        {
            _busesBLL.Insert(bus);
            return Ok();
        }
    }
}
