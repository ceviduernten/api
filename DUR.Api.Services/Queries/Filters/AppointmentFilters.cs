using System;
using System.Linq;
using DUR.Api.Entities;

namespace DUR.Api.Services.Queries.Filters;

public static class AppointmentFilters
{
    public static IQueryable<Appointment> FilterByGroup(this IQueryable<Appointment> entities, Guid group)
    {
        return entities.Where(a => a.GroupId == group);
    }
}