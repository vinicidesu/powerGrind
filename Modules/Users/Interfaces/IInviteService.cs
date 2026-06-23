namespace powerGrind.Modules.Users.Interfaces
{
    public interface IInviteService
    {
        Task<bool> SendInviteAsync(string? email, string? phoneNumber, string role);
        Task<bool> CompleteInviteAsync(string token, string password);
    }
}
