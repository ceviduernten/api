using DUR.Api.Entities;
using DUR.Api.Repo.Nextcloud.Interfaces;
using DUR.Api.Repo.Kool.Interfaces;
using DUR.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DUR.Api.Services.Services
{
    public class EventService : IEventService
    {
        private readonly IEventsRepo _repo;
        private readonly IKoolEventsRepo _koolEventsRepo;

        public EventService(INextcloudUnitOfWorkFactory nextcloudUnitOfWorkFactory, IKoolUnitOfWorkFactory koolUnitOfWorkFactory)
        {
            INextcloudUnitOfWork _nextcloudUnitOfWork = nextcloudUnitOfWorkFactory.Create();
            _repo = _nextcloudUnitOfWork.EventsRepo();

            IKoolUnitOfWork _koolUnitOfWork = koolUnitOfWorkFactory.Create();
            _koolEventsRepo = _koolUnitOfWork.EventsRepo();

        }

        public List<Event> GetCurrentEvents()
        {
            _koolEventsRepo.GetEvents();
            return _repo.GetEvents().OrderBy(x => x.Start).ToList();
        }
    }
}
