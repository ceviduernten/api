using System;
using System.Text;
using DUR.Api.Entities;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Services.Services
{
    public class GroupMailService : IGroupMailService
    {
        private readonly IMailService _mailService;
        private readonly IGroupService _groupService;

        public GroupMailService(IMailService mailService, IGroupService groupService)
        {
            _mailService = mailService;
            _groupService = groupService;
        }

        public bool InformGroup(Appointment appointment)
        {
            Group group = _groupService.GetById(appointment.GroupId);
            if (group == null)
            {
                // TODO LOG HERE
                return false;
            }

            if (string.IsNullOrEmpty(group.Mail))
            {
                // Send than no Mail
                return true;
            }

            string subject = string.Format("Cevi Dürnten | Chästlizettel der Gruppe " + group.Name + " für den " + appointment.Date.ToString("dd.MM.yyyy"));
            string message = GetInfos(appointment, group, false);

            bool success = _mailService.SendMail(subject, message, group.Mail);

            return success;
        }

        public bool InformLeaders(Appointment appointment)
        {
            Group group = _groupService.GetById(appointment.GroupId);
            if (group == null)
            {
                // TODO LOG HERE
                return false;
            }

            if (string.IsNullOrEmpty(group.MailLeaders))
            {
                // Send than no Mail
                return true;
            }

            string subject = string.Format("Cevi Dürnten | Chästlizettel der Gruppe " + group.Name + " für den " + appointment.Date.ToString("dd.MM.yyyy"));
            string message = GetInfos(appointment, group, true);

            bool success = _mailService.SendMail(subject, message, group.MailLeaders);

            return success;
        }

        public bool SignOff()
        {
            throw new NotImplementedException();
        }

        public bool SignOn()
        {
            throw new NotImplementedException();
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
            sb.AppendLine("<p>Die Infos kannst du online auf der Homepage unter dem untenstehendem Link oder in der Mobile App des Cevi Dürnten einsehen.<br/>");
            sb.AppendLine("<a href='https://ceviduernten.ch/jungschar/chaestlizettel.html'>Link zur Homepage</a></p>");
            sb.AppendLine("<br/>");
            sb.AppendLine("<p>Freundliche Grüsse<br/>Dein Leiterteam vom Cevi Dürnten</p>");
            return sb.ToString();
        }
    }   
}
