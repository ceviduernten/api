using DUR.Api.Entities;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services
{
    public class ContactService : DatabaseServiceBase<Contact>, IContactService
    {
        public ContactService(IDatabaseUnitOfWorkFactory unitOfWorkFactory)
        {
            databaseUnitOfWork = unitOfWorkFactory.Create();
            querier = new ContactQueries(databaseUnitOfWork);
        }
    }
}
