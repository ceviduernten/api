using System;
using System.Collections.Generic;
using DUR.Api.Entities;
using DUR.Api.Repo.Nextcloud.Interfaces;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Services.Services
{
    public class EventService : IEventService
    {
        private readonly IEventsRepo _repo;

        public EventService(INextcloudUnitOfWorkFactory nextcloudUnitOfWorkFactory)
        {
            INextcloudUnitOfWork _nextcloudUnitOfWork = nextcloudUnitOfWorkFactory.Create();
            _repo = _nextcloudUnitOfWork.EventsRepo();

        }

        public List<Event> GetCurrentEvents()
        {
            return _repo.GetEvents(null, null);
        }
    }
}
