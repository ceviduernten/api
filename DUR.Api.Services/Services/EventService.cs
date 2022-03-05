using System.Collections.Generic;
using System.Linq;
using DUR.Api.Entities;
using DUR.Api.Repo.Kool.Interfaces;
using DUR.Api.Repo.Nextcloud.Interfaces;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Services.Services;

public class EventService : IEventService
{
    private readonly IKoolEventsRepo _koolEventsRepo;
    private readonly IEventsRepo _repo;

    public EventService(INextcloudUnitOfWorkFactory nextcloudUnitOfWorkFactory,
        IKoolUnitOfWorkFactory koolUnitOfWorkFactory)
    {
        var _nextcloudUnitOfWork = nextcloudUnitOfWorkFactory.Create();
        _repo = _nextcloudUnitOfWork.EventsRepo();

        var _koolUnitOfWork = koolUnitOfWorkFactory.Create();
        _koolEventsRepo = _koolUnitOfWork.EventsRepo();
    }

    public List<Event> GetCurrentEvents()
    {
        _koolEventsRepo.GetEvents();
        return _repo.GetEvents().OrderBy(x => x.Start).ToList();
    }
}