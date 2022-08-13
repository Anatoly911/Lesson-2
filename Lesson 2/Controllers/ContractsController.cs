using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractsController : ControllerBase
    {
        [HttpGet("api/contracts/get")]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("api/contracts/get/{id}")]
        public IActionResult Get(int agentId)
        {
            return Ok();
        }
        [HttpPost("api/contracts/register")]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpPut("api/contracts/update/{id}")]
        public IActionResult Put(int agentId)
        {
            return Ok();
        }
        [HttpDelete("api/contracts/delete/{id}")]
        public IActionResult Delete(int agentId)
        {
            return Ok();
        }
    }
}
