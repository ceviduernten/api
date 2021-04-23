using DUR.Api.Entities.Easter;

namespace DUR.Api.Services.Interfaces
{
    public interface IHuntLocationService : IDatabaseService<HuntLocation>
    {
        bool ActivateAllLocations();
    }
}
