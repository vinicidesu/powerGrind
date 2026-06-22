using powerGrind.Modules.Users.Entities;

namespace powerGrind.Modules.Users.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<User?>> GetAllUsersAsync();
        public Task<User?> GetUserByEmailAsync(string email);
        public Task<User?> GetUserByIdAsync(Guid id);
        public Task<bool> CreateUserAsync(User user);
        public Task<bool> UpdateUserAsync(User user);
        public Task<bool> DeleteUserAsync(Guid id);

    }
}
