using System;
using System.Linq;
using DUR.Api.Entities;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Queries.Filters;

namespace DUR.Api.Services.Queries;

public class AppointmentQueries : DatabaseBaseQueries<Appointment>
{
    public AppointmentQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _repository = unitOfWork.AppointmentRepository();
    }

    public IQueryable<Appointment> GetFilteredByGroup(Guid group)
    {
        var appointments = _repository.GetAll().AsQueryable();
        appointments = appointments.FilterByGroup(group);
        return appointments;
    }
}