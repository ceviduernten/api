using System;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities;

public class AppointmentResponse : Base
{
    public Guid IdAppointmentResponse { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
    public AppointmentResponseType Type { get; set; }

    public Guid AppointmentId { get; set; }
    public Appointment Appointment { get; set; }
}