using DUR.Api.Entities;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Services.Queries
{
    public class ContactQueries : DatabaseBaseQueries<Contact>
    {
        public ContactQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.ContactRepository();
        }
    }
}
