using DUR.Api.Entities;
using DUR.Api.Repo.Kool.Interfaces;
using DUR.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DUR.Api.Services.Services
{
    public class KoolEventService : IKoolEventService
    {
        private readonly IKoolEventsRepo _koolEventsRepo;

        public KoolEventService(IKoolUnitOfWorkFactory koolUnitOfWorkFactory)
        {

            IKoolUnitOfWork _koolUnitOfWork = koolUnitOfWorkFactory.Create();
            _koolEventsRepo = _koolUnitOfWork.EventsRepo();

        }

        public List<KoolEvent> GetEvents()
        {
            return _koolEventsRepo.GetEvents().OrderBy(x => x.Start).ToList();
        }

        public List<KoolEvent> GetReservations()
        {
            return _koolEventsRepo.GetReservations().OrderBy(x => x.Start).ToList();
        }
    }
}
