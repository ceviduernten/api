using DUR.Api.Entities;
using System;

namespace DUR.Api.Presentation.ResourceModel
{
    public class AppointmentResponseRM : BaseRM
    {
        public Guid IdAppointment { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public AppointmentResponseType Type { get; set; } 
    }
}
