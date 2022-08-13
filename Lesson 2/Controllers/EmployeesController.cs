using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("api/employees/get")]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("api/employees/get/{id}")]
        public IActionResult Get(int agentId)
        {
            return Ok();
        }
        [HttpPost("api/employees/register")]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpPut("api/employees/update/{id}")]
        public IActionResult Put(int agentId)
        {
            return Ok();
        }
        [HttpDelete("api/employees/delete/{id}")]
        public IActionResult Delete(int agentId)
        {
            return Ok();
        }
    }
}
