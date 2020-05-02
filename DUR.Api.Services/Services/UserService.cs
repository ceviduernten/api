using DUR.Api.Entities.Admin;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services
{
    public class UserService : DatabaseServiceBase<User>, IUserService
    {
        public UserService(IDatabaseUnitOfWorkFactory unitOfWorkFactory)
        {
            databaseUnitOfWork = unitOfWorkFactory.Create();
            querier = new UserQueries(databaseUnitOfWork);
        }
    }
}
