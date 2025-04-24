namespace WebApiMaghazia.Repository
{
    public interface IEmailSender
    {
        Task<string> SendOTPEmailAsync(string email, string message);
    }
}
