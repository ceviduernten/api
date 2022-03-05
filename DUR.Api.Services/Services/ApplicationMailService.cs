using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Services.Interfaces;
using System.Text;
using DUR.Api.Entities.Kool;
using DUR.Api.Settings;

namespace DUR.Api.Services.Services
{
    public class ApplicationMailService : IApplicationMailService
    {
        private readonly IMailService _mailService;
        private readonly IApplicationLogger _logger;

        public ApplicationMailService(IMailService mailService, IApplicationLogger logger)
        {
            _mailService = mailService;
            _logger = logger;
        }

        private void GetSalution(StringBuilder message, Reservation reservation, bool requester = false)
        {
            if (requester)
            {
                message.AppendLine("<p><b>Liebe(r) " + reservation.FirstName + "</b></p>");
            }
            else
            {
                message.AppendLine("<p><b>Lieber Aktuar</b></p>");
            }
        }

        private void GetReservation(StringBuilder message, Reservation reservation)
        {
            message.Append("<p>");
            message.Append("<b>Details zur Reservation</b><br/>");
            message.Append("Titel: " + reservation.Title + "<br/>");
            message.Append("Datum: " + reservation.Date.ToString("dd.MM.yyyy") + "<br/>");
            message.Append("Start: " + reservation.Start + "<br/>");
            message.Append("Ende: " + reservation.End + "<br/>");
            message.Append("Resevierende Person: " + reservation.FirstName + " " + reservation.LastName + "<br/>");
            message.Append("Mail: " + reservation.Mail + "<br/>");
            message.Append("Räume: " + reservation.Rooms + "<br/>");
            message.Append("Datum: " + reservation.Date.ToString("dd.MM.yyyy") + "<br/>");
            message.Append("</p>");
        }

        private string GetReservationMessage(Reservation reservation, bool requester = false)
        {
            StringBuilder sb = new StringBuilder();
            GetSalution(sb, reservation, requester);
            GetReservation(sb, reservation);
            if (requester)
            {
                sb.AppendLine(
                    "Die Reservation wird dir in den nächsten Tag noch bestätigt. Zum jetztigen Zeitpunkt ist diese nur provisorisch und wird online auch nicht angezeigt.");
            }
            sb.AppendLine("<p>Freundliche Grüsse<br/>Die tüchtigen digitalen Wichtel vom Cevi Dürnten</p>");
            return sb.ToString();
        }

        public bool InformAboutReservation(Reservation reservation)
        {
            if (string.IsNullOrEmpty(reservation.Mail))
            {
                // Send than no Mail
                return true;
            }

            string subject = string.Format("Reservation für Räume vom " + reservation.Date.ToString("dd.MM.yyyy"));
            string messageForRequester = GetReservationMessage(reservation, true);
            string messageForAktuar = GetReservationMessage(reservation, false);

            bool success = _mailService.SendMail(subject, messageForAktuar, "***REMOVED***", "Raumreservation", FooterType.GENERAL);
            if (success)
            {
                success = _mailService.SendMail(subject, messageForRequester, reservation.Mail, "Raumreservation", FooterType.GENERAL);
            }
            return success;
        }
    }   
}
