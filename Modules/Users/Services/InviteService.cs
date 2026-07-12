using Microsoft.Extensions.Options;
using powerGrind.Modules.Users.Entities;
using powerGrind.Modules.Users.Interfaces;
using powerGrind.Shared.Database;
using Resend;

namespace powerGrind.Modules.Users.Services
{
    public class InviteService : IInviteService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;
        private readonly IResend _resend;

        public InviteService(AppDbContext appDbContext, IConfiguration configuration, IUserRepository userRepository, IHttpClientFactory httpClientFactory, ILogger logger, IResend resend)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _userRepository = userRepository;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _resend = resend;
        }

        public async Task<bool> SendInviteAsync(string? email, string? phoneNumber, string role)
        {
            var invite = new Invite
            {
                Email = email,
                PhoneNumber = phoneNumber,
                Role = role,
                Token = Guid.NewGuid().ToString(),
                ExpiresAt = DateTime.UtcNow.AddDays(2)
            };

            _appDbContext.Add(invite);
            await _appDbContext.SaveChangesAsync();

            if (email != null)
            {
                var message = new EmailMessage
                {
                    From = "onboarding@resend.dev",
                    To = [email],
                    Subject = "Você foi convidado para o powerGrind",
                    HtmlBody = $"<p>Clique no link para completar seu cadastro: <a href='https://app.powergrind.com/complete?token={invite.Token}'>Aceitar convite</a></p>"
                };

                await _resend.EmailSendAsync(message);
            }

            return true;
        }

        public async Task<bool> CompleteInviteAsync(string token, string password)
        {
            return true;
        }
    }
}
