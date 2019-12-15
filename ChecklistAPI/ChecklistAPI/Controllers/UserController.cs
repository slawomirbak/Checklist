using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checklist.Abstract.Contract;
using Checklist.Abstract.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Checklist.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                var errorResponse = await _userService.Add(userDto);
                if (!errorResponse.IsSuccessful)
                {
                    return new BadRequestObjectResult(errorResponse.ErrorMessage);
                }
                return new OkObjectResult(errorResponse);
            }
            return BadRequest();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CredentialDto credentials)
        {
            if (ModelState.IsValid)
            {
                var errorResponse = await _userService.Login(credentials);
                if (!errorResponse.IsSuccessful)
                {
                    return new BadRequestObjectResult(errorResponse.ErrorMessage);
                }
                return new OkObjectResult(errorResponse);
            }
            return BadRequest();
        }
    }
}