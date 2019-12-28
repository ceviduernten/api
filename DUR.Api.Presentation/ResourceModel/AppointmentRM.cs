using System;
using DUR.Api.Entities.Events;

namespace DUR.Api.Presentation.ResourceModel
{
    public class AppointmentRM : BaseRM
    {
        public Guid IdAppointment { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public string Infos { get; set; }

        public Guid GroupId { get; set; }
        public GroupRM Group { get; set; }
    }
}
