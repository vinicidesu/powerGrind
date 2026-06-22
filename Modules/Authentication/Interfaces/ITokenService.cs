using powerGrind.Modules.Users.Entities;

namespace powerGrind.Modules.Authentication.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
