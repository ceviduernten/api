using System;
using System.Collections.Generic;
using System.Linq;
using DUR.Api.Entities;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services
{
    public class AppointmentService : DatabaseServiceBase<Appointment>, IAppointmentService
    {
        public AppointmentService(IDatabaseUnitOfWorkFactory unitOfWorkFactory)
        {
            databaseUnitOfWork = unitOfWorkFactory.Create();
            querier = new AppointmentQueries(databaseUnitOfWork);
        }

        public List<Appointment> GetAppointmentsByGroup(Guid group)
        {
            var appointments = (querier as AppointmentQueries).GetFilteredByGroup(group).ToList();
            return appointments;
        }
    }
}
