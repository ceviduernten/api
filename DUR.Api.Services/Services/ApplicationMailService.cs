using System.Text;
using DUR.Api.Entities.Kool;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Settings;

namespace DUR.Api.Services.Services;

public class ApplicationMailService : IApplicationMailService
{
    private readonly IApplicationLogger _logger;
    private readonly IMailService _mailService;

    public ApplicationMailService(IMailService mailService, IApplicationLogger logger)
    {
        _mailService = mailService;
        _logger = logger;
    }

    public bool InformAboutReservation(Reservation reservation)
    {
        if (string.IsNullOrEmpty(reservation.Mail))
            // Send than no Mail
            return true;

        var subject = string.Format("Reservation für Räume vom " + reservation.Date.ToString("dd.MM.yyyy"));
        var messageForRequester = GetReservationMessage(reservation, true);
        var messageForAktuar = GetReservationMessage(reservation);

        var success = _mailService.SendMail(subject, messageForAktuar, "***REMOVED***", "Raumreservation",
            FooterType.GENERAL);
        if (success)
            success = _mailService.SendMail(subject, messageForRequester, reservation.Mail, "Raumreservation",
                FooterType.GENERAL);
        return success;
    }

    private void GetSalution(StringBuilder message, Reservation reservation, bool requester = false)
    {
        if (requester)
            message.AppendLine("<p><b>Liebe(r) " + reservation.FirstName + "</b></p>");
        else
            message.AppendLine("<p><b>Lieber Aktuar</b></p>");
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
        var sb = new StringBuilder();
        GetSalution(sb, reservation, requester);
        GetReservation(sb, reservation);
        if (requester)
            sb.AppendLine(
                "Die Reservation wird dir in den nächsten Tag noch bestätigt. Zum jetztigen Zeitpunkt ist diese nur provisorisch und wird online auch nicht angezeigt.");
        sb.AppendLine("<p>Freundliche Grüsse<br/>Die tüchtigen digitalen Wichtel vom Cevi Dürnten</p>");
        return sb.ToString();
    }
}