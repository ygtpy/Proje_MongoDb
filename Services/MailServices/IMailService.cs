namespace AkademiQMongoDb.Services.MailServices
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
