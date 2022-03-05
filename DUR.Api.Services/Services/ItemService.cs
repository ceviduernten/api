using DUR.Api.Entities.Stuff;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services;

public class ItemService : DatabaseServiceBase<Item>, IItemService
{
    public ItemService(IDatabaseUnitOfWorkFactory unitOfWorkFactory, IApplicationLogger logger) : base(logger)
    {
        databaseUnitOfWork = unitOfWorkFactory.Create();
        querier = new ItemQueries(databaseUnitOfWork);
    }
}