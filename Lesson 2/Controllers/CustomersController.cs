using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        [HttpGet("api/customers/get")]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("api/customers/get/{id}")]
        public IActionResult Get(int agentId)
        {
            return Ok();
        }
        [HttpPost("api/customers/register")]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpPut("api/customers/update/{id}")]
        public IActionResult Put(int agentId)
        {
            return Ok();
        }
        [HttpDelete("api/customers/delete/{id}")]
        public IActionResult Delete(int agentId)
        {
            return Ok();
        }
    }
}
