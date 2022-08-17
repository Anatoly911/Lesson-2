using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController : ControllerBase
    {
        [HttpGet("api/invoices/get")]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPut("api/invoices/update")]
        public IActionResult Put()
        {
            return Ok();
        }
    }
}
