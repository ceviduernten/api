using DUR.Api.Entities;
using DUR.Api.Entities.Stuff;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services
{
    public class ItemService : DatabaseServiceBase<Item>, IItemService
    {
        public ItemService(IDatabaseUnitOfWorkFactory unitOfWorkFactory)
        {
            databaseUnitOfWork = unitOfWorkFactory.Create();
            querier = new ItemQueries(databaseUnitOfWork);
        }
    }
}
