using Lesson_2.Entity;
using Lesson_2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Lesson_2.Controllers
{
    public class UsersController : Controller
    {
        private readonly Users _users;
        private readonly ILogger<UsersController> _logger;
        public UsersController(Users users, ILogger<UsersController> logger)
        {
            _users = users;
            _logger = logger;
        }
        [HttpGet("api/users/{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }
        [HttpGet("api/users/search?searchTerm={term}")]
        public IActionResult Get(string term)
        {
            return Ok();
        }
        [HttpGet("api/users/?skip={5}&take={10}")]
        public IActionResult Post(int skip, int take)
        {
            return Ok();
        }
        [HttpPost("api/users")]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpPut("api/users")]
        public IActionResult Put()
        {
            return Ok();
        }
        [HttpDelete("api/users/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
