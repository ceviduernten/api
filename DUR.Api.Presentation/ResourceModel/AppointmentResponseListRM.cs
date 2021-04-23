using System;
using DUR.Api.Entities;
using DUR.Api.Entities.Default;

namespace DUR.Api.Presentation.ResourceModel
{
    public class AppointmentResponseListRM : BaseRM
    {
        public Guid IdAppointmentResponse { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public AppointmentResponseType Type { get; set; }

        public Guid AppointmentId { get; set; }
    }
}
