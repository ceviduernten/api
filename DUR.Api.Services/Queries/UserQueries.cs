using System;
using DUR.Api.Entities;
using DUR.Api.Entities.Admin;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Services.Queries
{
    public class UserQueries : DatabaseBaseQueries<User>
    {
        public UserQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.UserRepository();
        }
    }
}
