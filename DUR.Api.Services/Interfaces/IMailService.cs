namespace DUR.Api.Services.Interfaces
{
    public interface IMailService
    {
        bool SendMail(string subject, string messageBody, string recipient);
        bool SendMailInNameof(string subject, string messageBody, string recipient, string sender);

    }
}
