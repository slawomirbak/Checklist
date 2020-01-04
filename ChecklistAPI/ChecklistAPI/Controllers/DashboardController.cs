using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Checklist.Abstract.Contract;
using Checklist.Abstract.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Checklist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardController(IDashboardService dashboardService, IHttpContextAccessor httpContextAccessor)
        {
            _dashboardService = dashboardService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<ActionResult> AddList([FromBody]ChecklistDto checklist)
        {
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var response = await _dashboardService.Add(checklist, userEmail);
            return new BadRequestResult();
        }
    }
}
