using Microsoft.EntityFrameworkCore;
using powerGrind.Modules.Users.Entities;
using powerGrind.Modules.Users.Interfaces;
using powerGrind.Shared.Database;

namespace powerGrind.Modules.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<User?>> GetAllUsersAsync() 
        {
            var users = await _appDbContext.Users.ToListAsync();

            return users;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }
    }
}
