using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using DUR.Api.Services.Interfaces;
using DUR.Api.Settings;
using Microsoft.Extensions.Options;

namespace DUR.Api.Services.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _settings;

        public MailService(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        private void BuildMailMessage(MailMessage message, string messageBody)
        {
            Stream htmlStream = null;
            Stream logoStream = null;

            message.Headers.Add("Content-Type", "content=text/html; charset=\"UTF-8\"");

            try
            {
                var resourceAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "DUR.Api.Settings");

                htmlStream = resourceAssembly.GetManifestResourceStream("DUR.Api.Settings.Templates.MailTemplate.html");
                var reader = new StreamReader(htmlStream);
                var body = reader.ReadToEnd().Replace("%MAIN_CONTENT%", messageBody);

                var altView = AlternateView.CreateAlternateViewFromString(body, Encoding.UTF8, MediaTypeNames.Text.Html);
                message.AlternateViews.Add(altView);
                message.IsBodyHtml = true;

                logoStream = resourceAssembly.GetManifestResourceStream("DUR.Api.Settings.Images.Logo.png");
                var logo = new LinkedResource(logoStream, "image/png")
                {
                    ContentId = "Logo.png"
                };
                altView.LinkedResources.Add(logo);
            }
            catch (Exception ex)
            {
                // Do nothing at the moment
            }
        }

        public bool SendMail(string subject, string messageBody, string recipient)
        {
            bool success = false;
            MailMessage message = new MailMessage(_settings.SenderAddress, recipient)
            {
                Subject = subject,
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.Unicode,
                IsBodyHtml = true
            };
            BuildMailMessage(message, messageBody);
            SmtpClient client = new SmtpClient(_settings.Host, _settings.HostPort)
            {
                EnableSsl = true,
                Timeout = 500000000,
                Credentials = new System.Net.NetworkCredential(_settings.HostUsername, _settings.HostPassword)
            };
            try
            {
                client.Send(message);
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }
            return success;
        }

        public bool SendMailInNameof(string subject, string messageBody, string recipient, string sender)
        {
            bool success = true;
            MailMessage message = new MailMessage(sender, recipient)
            {
                Subject = subject,
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };
            BuildMailMessage(message, messageBody);
            SmtpClient client = new SmtpClient(_settings.Host, _settings.HostPort)
            {
                EnableSsl = true,
                Timeout = 500000000,
                Credentials = new System.Net.NetworkCredential(_settings.HostUsername, _settings.HostPassword)
            };
            try
            {
                client.Send(message);
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }
            return success;
        }
    }
}
