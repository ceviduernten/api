using DUR.Api.Entities;
using System.Collections.Generic;

namespace DUR.Api.Services.Interfaces
{
    public interface IKoolEventService
    {
        List<KoolEvent> GetEvents();
        List<KoolEvent> GetReservations();
    }
}
