using DUR.Api.Entities;
using System.Collections.Generic;

namespace DUR.Api.Repo.Kool.Interfaces
{
    public interface IKoolEventsRepo
    {
        List<KoolEvent> GetEvents();
        List<KoolEvent> GetReservations();
    }
}
