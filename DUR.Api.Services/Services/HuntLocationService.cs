using DUR.Api.Entities.Easter;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services;

public class HuntLocationService : DatabaseServiceBase<HuntLocation>, IHuntLocationService
{
    public HuntLocationService(IDatabaseUnitOfWorkFactory unitOfWorkFactory, IApplicationLogger logger) : base(logger)
    {
        databaseUnitOfWork = unitOfWorkFactory.Create();
        querier = new HuntLocationQueries(databaseUnitOfWork);
    }

    public bool ActivateAllLocations()
    {
        var success = true;
        var all = GetAll();
        foreach (var location in all)
        {
            location.IsActive = true;
            success = Update(location) != null;
        }

        return success;
    }
}