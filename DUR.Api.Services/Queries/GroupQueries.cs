using DUR.Api.Entities;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Services.Queries
{
    public class GroupQueries : DatabaseBaseQueries<Group>
    {
        public GroupQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GroupRepository();
        }
    }
}
