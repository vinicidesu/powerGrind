using Microsoft.AspNetCore.Mvc;
using powerGrind.Modules.Authentication.DTOs;
using powerGrind.Modules.Authentication.Interfaces;

namespace powerGrind.Modules.Authentication.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var response = await _authService.Login(request);

                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized login attempt");
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                return StatusCode(500);
            }
        }
    }
}
