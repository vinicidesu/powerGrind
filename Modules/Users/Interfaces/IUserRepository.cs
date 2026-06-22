using powerGrind.Modules.Users.Entities;

namespace powerGrind.Modules.Users.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User?>> GetAllUsersAsync();
        public Task<User?> GetUserByEmailAsync(string email);
    }
}
