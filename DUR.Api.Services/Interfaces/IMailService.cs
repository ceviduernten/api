using System.Collections.Generic;
using System.Net.Mail;
using DUR.Api.Settings;

namespace DUR.Api.Services.Interfaces;

public interface IMailService
{
    bool SendMail(string subject, string messageBody, string recipient, string header, FooterType type, Attachment attachment = null);

    bool SendMailInNameof(string subject, string messageBody, string recipient, string sender, string header,
        FooterType type);
}