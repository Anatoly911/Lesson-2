﻿using Lesson_2.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly Person _person;

        public PersonController(ILogger<PersonController> logger, Person person)
        {
            _person = person;
            _logger = logger;
        }
        [HttpGet("api/persons/{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }
        [HttpGet("api/persons/search?searchTerm={term}")]
        public IActionResult Get(string term)
        {
            return Ok();
        }
        [HttpGet("api/persons/?skip={5}&take={10}")]
        public IActionResult Post(int skip, int take)
        {
            return Ok();
        }
        [HttpPost("api/persons")]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpPut("api/persons")]
        public IActionResult Put()
        {
            return Ok();
        }
        [HttpDelete("api/persons/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
