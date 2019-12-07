using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Checklist.WebApi.Controllers
{
    public class UserController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}