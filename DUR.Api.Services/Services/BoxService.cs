using DUR.Api.Entities.Stuff;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services
{
    public class BoxService : DatabaseServiceBase<Box>, IBoxService
    {
        public BoxService(IDatabaseUnitOfWorkFactory unitOfWorkFactory)
        {
            databaseUnitOfWork = unitOfWorkFactory.Create();
            querier = new BoxQueries(databaseUnitOfWork);
        }
    }
}
