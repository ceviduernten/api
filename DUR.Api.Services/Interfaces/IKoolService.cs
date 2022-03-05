using System.Collections.Generic;
using DUR.Api.Entities.Kool;

namespace DUR.Api.Services.Interfaces;

public interface IKoolService
{
    List<KoolEvent> GetEvents();
    List<KoolReservation> GetReservations();
}