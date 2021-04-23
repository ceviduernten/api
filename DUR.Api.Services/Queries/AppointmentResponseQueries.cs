using System;
using System.Linq;
using DUR.Api.Entities;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Queries.Filters;

namespace DUR.Api.Services.Queries
{
    public class AppointmentResponseQueries : DatabaseBaseQueries<AppointmentResponse>
    {
        public AppointmentResponseQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.AppointmentResponseRepository();
        }
    }
}
