using System;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities
{
    public class AppointmentResponse : Base
    {
        public Guid IdAppointment { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public AppointmentResponseType Type { get; set; }
    }
}
