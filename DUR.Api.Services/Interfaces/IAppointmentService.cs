using DUR.Api.Entities;
using System;
using System.Collections.Generic;

namespace DUR.Api.Services.Interfaces
{
    public interface IAppointmentService : IDatabaseService<Appointment>
    {
        List<Appointment> GetAppointmentsByGroup(Guid group);
    }
}
