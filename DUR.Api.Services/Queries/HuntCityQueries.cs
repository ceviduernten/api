using DUR.Api.Entities.Easter;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Services.Queries
{
    public class HuntCityQueries : DatabaseBaseQueries<HuntCity>
    {
        public HuntCityQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.HuntCityRepository();
        }
    }
}
