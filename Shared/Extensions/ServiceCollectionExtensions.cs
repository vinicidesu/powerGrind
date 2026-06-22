using powerGrind.Modules.Authentication.Interfaces;
using powerGrind.Modules.Authentication.Services;
using powerGrind.Modules.Users.Interfaces;
using powerGrind.Modules.Users.Repositories;
using powerGrind.Modules.Users.Services;

namespace powerGrind.Shared.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services) 
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
