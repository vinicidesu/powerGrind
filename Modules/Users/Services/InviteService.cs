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

        public InviteService(AppDbContext appDbContext, IConfiguration configuration, IUserRepository userRepository, IHttpClientFactory httpClientFactory)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _userRepository = userRepository;
            _httpClientFactory = httpClientFactory;
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
                //var options = new ResendClientOptions 
                //{ 
                //    ApiToken = _configuration["Resend:ApiKey"]!
                //};

                //var httpClient = _httpClientFactory.CreateClient();

                //var resend = new ResendClient(Options.Create(options), httpClient);

                //var message = new EmailMessage
                //{
                //    From = "invite@seudominio.com",
                //    To = [email],
                //    Subject = "Você foi convidado para o powerGrind",
                //    HtmlBody = $"<p>Clique no link para completar seu cadastro: <a href='https://app.powergrind.com/complete?token={invite.Token}'>Aceitar convite</a></p>"
                //};

                //await resend.EmailSendAsync(message);
            }

            return true;
        }

        public async Task<bool> CompleteInviteAsync(string token, string password)
        {
            return true;
        }
    }
}
