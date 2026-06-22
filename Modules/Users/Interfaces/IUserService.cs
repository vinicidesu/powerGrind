using powerGrind.Modules.Users.Entities;

namespace powerGrind.Modules.Users.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User?>> GetAllUsersAsync();
        Task<User?> GetUserByEmailAsync(string email);
        
    }
}
