using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.Responses;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _userService;

        public SecurityController(ISecurityService userService)
        {
            _userService = userService;
        }

        [HttpPost("{login}")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var service = await _userService.Get(userName, password);
            var response = new ApiResponse<Security>(service);
            return Ok(response);
        }

    }
}