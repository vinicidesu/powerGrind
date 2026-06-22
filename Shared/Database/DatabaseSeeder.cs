using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using powerGrind.Modules.Users.Entities;

namespace powerGrind.Shared.Database
{
    public static class DatabaseSeeder
    {
        public static void Seed(AppDbContext context, IConfiguration _configuration)
        {
            var user = context.Users.FirstOrDefault(u => u.Role == "Admin");

            if (user == null)
            {
                context.Users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Email = _configuration["Seed:AdminEmail"] ?? "",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(_configuration["Seed:AdminPassword"]),
                    Role = "Admin",
                    Active = true,
                });

                context.SaveChanges();
            }
        }
    }
}
