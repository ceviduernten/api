using DUR.Api.Entities;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Services.Interfaces;
using System.Text;
using DUR.Api.Settings;

namespace DUR.Api.Services.Services
{
    public class GroupMailService : IGroupMailService
    {
        private readonly IMailService _mailService;
        private readonly IGroupService _groupService;
        private readonly IAppointmentService _appointmentService;
        private readonly IApplicationLogger _logger;

        public GroupMailService(IMailService mailService, IGroupService groupService, IAppointmentService appointmentService, IApplicationLogger logger)
        {
            _mailService = mailService;
            _groupService = groupService;
            _appointmentService = appointmentService;
            _logger = logger;
        }

        public bool InformGroup(Appointment appointment)
        {
            Group group = _groupService.GetById(appointment.GroupId);
            if (group == null)
            {
                _logger.LogError("No group found with id " + appointment.GroupId);
                return false;
            }

            if (string.IsNullOrEmpty(group.Mail))
            {
                // Send than no Mail
                return true;
            }

            string subject = string.Format("Chästlizettel der Gruppe " + group.Name + " für den " + appointment.Date.ToString("dd.MM.yyyy"));
            string message = GetInfos(appointment, group, false);

            bool success = _mailService.SendMail(subject, message, group.Mail, "CHÄSTLIZETTEL", FooterType.GENERAL);

            return success;
        }

        public bool InformLeaders(Appointment appointment)
        {
            Group group = _groupService.GetById(appointment.GroupId);
            if (group == null)
            {
                _logger.LogError("No group found with id " + appointment.GroupId);
                return false;
            }

            if (string.IsNullOrEmpty(group.MailLeaders))
            {
                // Send than no Mail
                return true;
            }

            string subject = string.Format("Chästlizettel der Gruppe " + group.Name + " für den " + appointment.Date.ToString("dd.MM.yyyy"));
            string message = GetInfos(appointment, group, true);

            bool success = _mailService.SendMail(subject, message, group.MailLeaders, "CHÄSTLIZETTEL", FooterType.GENERAL);

            return success;
        }

        public bool SignOff(AppointmentResponse response)
        {
            Appointment appointment = _appointmentService.GetById(response.AppointmentId);
            Group group = _groupService.GetById(appointment.GroupId);
            if (group == null)
            {
                _logger.LogError("No group found with id " + appointment.GroupId);
                return false;
            }

            if (string.IsNullOrEmpty(group.MailLeaders))
            {
                // Send than no Mail
                return true;
            }

            string subject = string.Format("Abmeldung für den " + appointment.Date.ToString("dd.MM.yyyy"));
            string message = GetAppointmentResponseMessage(appointment, group, response);

            bool success = _mailService.SendMail(subject, message, group.MailLeaders,"CHÄSTLIZETTEL", FooterType.GENERAL);

            return success;
        }

        public bool SignOn(AppointmentResponse response)
        {
            Appointment appointment = _appointmentService.GetById(response.AppointmentId);
            Group group = _groupService.GetById(appointment.GroupId);
            if (group == null)
            {
                _logger.LogError("No group found with id " + appointment.GroupId);
                return false;
            }

            if (string.IsNullOrEmpty(group.MailLeaders))
            {
                // Send than no Mail
                return true;
            }

            string subject = string.Format("Anmeldung für den " + appointment.Date.ToString("dd.MM.yyyy"));
            string message = GetAppointmentResponseMessage(appointment, group, response);

            bool success = _mailService.SendMail(subject, message, group.MailLeaders, "CHÄSTLIZETTEL", FooterType.GENERAL);

            return success;
        }

        private string GetInfos(Appointment appointment, Group group, bool leader)
        {
            StringBuilder sb = new StringBuilder();
            if (leader)
            {
                sb.AppendLine("<p><b>Liebe Mitleiter und Mitleiterinnen</b></p>");
            } else
            {
                sb.AppendLine("<p><b>Liebe Eltern</b></p>");
            }
            sb.AppendLine("<p>Ein neuer Chästlizettel für das nächste Programm der Gruppe <b>" + group.Name + "</b> am " + appointment.Date.ToString("dd.MM.yyyy") + " wurde eingetragen.</p>");
            sb.AppendLine("<p>Die Infos kannst du online auf der Homepage unter dem untenstehendem Link oder in der Mobile App des Cevi Dürnten einsehen. An- und Abmelden ist dort direkt möglich.<br/>");
            sb.AppendLine("<a href='https://ceviduernten.ch/jungschar/chaestlizettel.html'>Link zur Homepage</a></p>");
            sb.AppendLine("<br/>");
            sb.AppendLine("<p>Freundliche Grüsse<br/>Dein Leiterteam vom Cevi Dürnten</p>");
            return sb.ToString();
        }

        private string GetAppointmentResponseMessage(Appointment appointment, Group group, AppointmentResponse response)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<p><b>Liebe Leiter und Leiterinnen</b></p>");
            if (response.Type == AppointmentResponseType.SIGNOFF)
            {
                sb.AppendLine("<p>Eine Abmeldung von " + response.Name + " für das nächste Programm deiner Gruppe <b>" + group.Name + "</b> am " + appointment.Date.ToString("dd.MM.yyyy") + " ist eingegangen.</p>");
            }
            if (response.Type == AppointmentResponseType.SIGNON)
            {
                sb.AppendLine("<p>Eine Anmeldung von " + response.Name + " für das nächste Programm deiner Gruppe <b>" + group.Name + "</b> am " + appointment.Date.ToString("dd.MM.yyyy") + " ist eingegangen.</p>");
            }
            
            sb.AppendLine("<p>" + response.Message +"</p><br/>");
            sb.AppendLine("<br/>");
            sb.AppendLine("<p>Freundliche Grüsse<br/>" + response.Name + "</p>");
            return sb.ToString();
        }
    }   
}
