using DUR.Api.Entities.Stuff;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Services.Queries
{
    public class StorageLocationQueries : DatabaseBaseQueries<StorageLocation>
    {
        public StorageLocationQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.StorageLocationRepository();
        }
    }
}
