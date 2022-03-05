using DUR.Api.Settings;

namespace DUR.Api.Services.Interfaces
{
    public interface IMailService
    {
        bool SendMail(string subject, string messageBody, string recipient, string header, FooterType type);
        bool SendMailInNameof(string subject, string messageBody, string recipient, string sender, string header, FooterType type);

    }
}
