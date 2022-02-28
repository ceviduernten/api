using DUR.Api.Entities;
using System.Collections.Generic;

namespace DUR.Api.Services.Interfaces
{
    public interface IKoolService
    {
        List<KoolEvent> GetEvents();
        List<KoolReservation> GetReservations();
    }
}
