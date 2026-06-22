using powerGrind.Modules.Authentication.DTOs;
using powerGrind.Modules.Authentication.Interfaces;
using powerGrind.Modules.Users.Interfaces;

namespace powerGrind.Modules.Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService) 
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email) ?? throw new UnauthorizedAccessException("Invalid user");
            bool verifyPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!verifyPassword)
            {
                throw new UnauthorizedAccessException("Invalid password");
            }

            var token = _tokenService.GenerateToken(user);
            var response = new LoginResponse 
            { 
                Token = token 
            };

            return response;
        }
    }
}
