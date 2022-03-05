using DUR.Api.Entities.Kool;

namespace DUR.Api.Services.Interfaces
{
    public interface IApplicationMailService
    {
        bool InformAboutReservation(Reservation reservation);
    }
}


