using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checklist.Abstract.Contract;
using Checklist.Abstract.IServices;
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
                await _userService.Add(userDto);
                return Ok();
            }
            return BadRequest();
        }
    }
}