using System;
using System.Collections.Generic;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities;

public class Appointment : Base
{
    public Guid IdAppointment { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public string Location { get; set; }
    public string Infos { get; set; }

    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    public List<AppointmentResponse> Responses { get; set; }
}