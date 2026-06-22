using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using powerGrind.Modules.Users.Interfaces;

namespace powerGrind.Modules.Users.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetAllUsersAsync();

            return Ok(response);
        }

        //public async Task<IActionResult> GetUser(Guid id)
        //{
        //    return Ok();
        //}

        //public async Task<IActionResult> CreateUser()
        //{
        //    return Ok();
        //}

        //public async Task<IActionResult> UpdateUser(Guid id)
        //{
        //    return Ok();
        //}

        //public async Task<IActionResult> DeleteUser(Guid id)
        //{
        //    return Ok();
        //}
    }
}
