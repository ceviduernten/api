using DUR.Api.Entities;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services;

public class AppointmentResponseService : DatabaseServiceBase<AppointmentResponse>, IAppointmentResponseService
{
    private readonly IGroupMailService _groupMailService;

    public AppointmentResponseService(IDatabaseUnitOfWorkFactory unitOfWorkFactory, IApplicationLogger logger,
        IGroupMailService groupMailService) : base(logger)
    {
        databaseUnitOfWork = unitOfWorkFactory.Create();
        querier = new AppointmentResponseQueries(databaseUnitOfWork);
        _groupMailService = groupMailService;
    }

    public bool SignOffForAppointment(AppointmentResponse response)
    {
        var success = Add(response) != null;
        if (success) success = _groupMailService.SignOff(response);
        return success;
    }

    public bool SignOnForAppointment(AppointmentResponse response)
    {
        var success = Add(response) != null;
        if (success) success = _groupMailService.SignOn(response);
        return success;
    }
}