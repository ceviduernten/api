using System;
using System.Collections.Generic;
using DUR.Api.Entities;

namespace DUR.Api.Services.Interfaces;

public interface IAppointmentService : IDatabaseService<Appointment>
{
    List<Appointment> GetAppointmentsByGroup(Guid group);
}