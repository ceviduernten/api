using DUR.Api.Entities.Stuff;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services
{
    public class StorageLocationService : DatabaseServiceBase<StorageLocation>, IStorageLocationService
    {
        public StorageLocationService(IDatabaseUnitOfWorkFactory unitOfWorkFactory, IApplicationLogger logger) : base(logger)
        {
            databaseUnitOfWork = unitOfWorkFactory.Create();
            querier = new StorageLocationQueries(databaseUnitOfWork);
        }
    }
}
