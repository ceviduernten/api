using System;
using DUR.Api.Entities;

namespace DUR.Api.Presentation.ResourceModel;

public class AppointmentResponseRM : BaseRM
{
    public Guid IdAppointment { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
    public AppointmentResponseType Type { get; set; }
}