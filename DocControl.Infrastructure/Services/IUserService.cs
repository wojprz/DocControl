namespace DocControl.Infrastructure.Services
{
    public interface IUserService
    {
        Task ChangePassword(string login, string newPassword, string oldPassword);
        Task ChangeEmail(string login, string email);
    }
}
