using DUR.Api.Entities.Easter;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Services.Queries;

public class HuntLocationQueries : DatabaseBaseQueries<HuntLocation>
{
    public HuntLocationQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _repository = unitOfWork.HuntLocationRepository();
    }
}