using DUR.Api.Entities;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services;

public class ContactService : DatabaseServiceBase<Contact>, IContactService
{
    public ContactService(IDatabaseUnitOfWorkFactory unitOfWorkFactory, IApplicationLogger logger) : base(logger)
    {
        databaseUnitOfWork = unitOfWorkFactory.Create();
        querier = new ContactQueries(databaseUnitOfWork);
    }
}