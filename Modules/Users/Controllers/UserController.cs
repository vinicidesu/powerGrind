using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using powerGrind.Modules.Users.DTOs;
using powerGrind.Modules.Users.Entities;
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

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var response = await _userService.GetAllUsersAsync();

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during get users.");
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                var response = await _userService.GetUserByIdAsync(id);

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during get user.");
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest user)
        {
            try
            {
                var response = await _userService.CreateUserAsync(new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role,
                    PasswordHash = user.Password
                });

                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during create user.");
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserRequest user)
        {
            try
            {
                var userToUpdate = await _userService.GetUserByIdAsync(id);

                if(userToUpdate == null)
                {
                    return NotFound();
                }

                var response = await _userService.UpdateUserAsync(new User
                {
                    Id = id,
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role,
                    PasswordHash = user.Password
                });

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during update user.");
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var response = await _userService.DeleteUserAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during delete user.");
                return StatusCode(500);
            }
        }
    }
}
