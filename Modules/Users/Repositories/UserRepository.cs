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

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var response = await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var userOrigin = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

            if (userOrigin != null)
            {
                userOrigin.Name = user.Name;
                userOrigin.Email = user.Email;
                userOrigin.Role = user.Role;
                userOrigin.PasswordHash = user.PasswordHash;
                userOrigin.Active = user.Active;

                await _appDbContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                _appDbContext.Users.Remove(user);
                await _appDbContext.SaveChangesAsync();
            }

            return true;
        }
    }
}
