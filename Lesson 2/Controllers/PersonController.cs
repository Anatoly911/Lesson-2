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
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _personService = personService;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromQuery] string user, string password)
        {
            TokenResponse token = _personService.Authenticate(user, password);
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
            string newRefreshToken = _personService.RefreshToken(oldRefreshToken);
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
