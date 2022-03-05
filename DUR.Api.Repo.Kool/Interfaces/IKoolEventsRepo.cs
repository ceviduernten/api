using System.Collections.Generic;
using DUR.Api.Entities.Kool;

namespace DUR.Api.Repo.Kool.Interfaces;

public interface IKoolEventsRepo
{
    List<KoolEvent> GetEvents();
    List<KoolReservation> GetReservations();
}