using DUR.Api.Entities.Easter;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services;

public class HuntCityService : DatabaseServiceBase<HuntCity>, IHuntCityService
{
    public HuntCityService(IDatabaseUnitOfWorkFactory unitOfWorkFactory, IApplicationLogger logger) : base(logger)
    {
        databaseUnitOfWork = unitOfWorkFactory.Create();
        querier = new HuntCityQueries(databaseUnitOfWork);
    }
}