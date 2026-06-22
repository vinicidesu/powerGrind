using Microsoft.EntityFrameworkCore;
using powerGrind.Modules.Users.Entities;

namespace powerGrind.Shared.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options
        ) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
