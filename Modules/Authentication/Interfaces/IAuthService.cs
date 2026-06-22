using powerGrind.Modules.Authentication.DTOs;
using powerGrind.Modules.Users.Entities;

namespace powerGrind.Modules.Authentication.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
