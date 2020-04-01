using System;
using DUR.Api.Entities;
using DUR.Api.Entities.Stuff;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Services.Queries
{
    public class BoxQueries : DatabaseBaseQueries<Box>
    {
        public BoxQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.BoxRepository();
        }
    }
}
