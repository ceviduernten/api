using DUR.Api.Entities;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Services.Queries;

public class AppointmentResponseQueries : DatabaseBaseQueries<AppointmentResponse>
{
    public AppointmentResponseQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _repository = unitOfWork.AppointmentResponseRepository();
    }
}