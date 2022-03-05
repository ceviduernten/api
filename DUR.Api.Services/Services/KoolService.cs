using System.Collections.Generic;
using System.Linq;
using DUR.Api.Entities.Kool;
using DUR.Api.Repo.Kool.Interfaces;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Services.Services;

public class KoolService : IKoolService
{
    private readonly IKoolEventsRepo _koolEventsRepo;

    public KoolService(IKoolUnitOfWorkFactory koolUnitOfWorkFactory)
    {
        var _koolUnitOfWork = koolUnitOfWorkFactory.Create();
        _koolEventsRepo = _koolUnitOfWork.EventsRepo();
    }

    public List<KoolEvent> GetEvents()
    {
        return _koolEventsRepo.GetEvents().OrderBy(x => x.Start).ToList();
    }

    public List<KoolReservation> GetReservations()
    {
        return _koolEventsRepo.GetReservations().OrderBy(x => x.Start).ToList();
    }
}