using System;
using System.Collections.Generic;
using System.Linq;
using DUR.Api.Entities;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services
{
    public class AppointmentService : DatabaseServiceBase<Appointment>, IAppointmentService
    {
        public AppointmentService(IDatabaseUnitOfWorkFactory unitOfWorkFactory, IApplicationLogger logger) : base(logger)
        {
            databaseUnitOfWork = unitOfWorkFactory.Create();
            querier = new AppointmentQueries(databaseUnitOfWork);
        }

        public List<Appointment> GetAppointmentsByGroup(Guid group)
        {
            var appointments = (querier as AppointmentQueries).GetFilteredByGroup(group).ToList();
            appointments = appointments.Where(x => x.Date >= DateTime.Now.AddDays(-1)).ToList();
            return appointments;
        }
    }
}
