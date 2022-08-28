using Lesson_2.Entity;
using Lesson_2.Services;
using Lesson_2.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeesService _employeesService;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeesService employeesService)
        {
            _employeesService = employeesService;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromQuery] string user, string password)
        {
            TokenResponse token = _employeesService.Authenticate(user, password);
            if (token is null)
            {
                return BadRequest(new
                {
                    message = "Username or password is incorrect"
                });
            }
            SetTokenCookie(token.RefreshToken);
            return Ok(token);
        }
        [Authorize]
        [HttpPost("refresh-token")]
        public IActionResult Refresh()
        {
            string oldRefreshToken = Request.Cookies["refreshToken"];
            string newRefreshToken = _employeesService.RefreshToken(oldRefreshToken);
            if (string.IsNullOrWhiteSpace(newRefreshToken))
            {
                return Unauthorized(new { message = "Invalid token" });
            }
            SetTokenCookie(newRefreshToken);
            return Ok(newRefreshToken);
        }
        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
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
