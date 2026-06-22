using powerGrind.Modules.Users.Entities;
using powerGrind.Modules.Users.Interfaces;

namespace powerGrind.Modules.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User?>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }githu
    }
}
