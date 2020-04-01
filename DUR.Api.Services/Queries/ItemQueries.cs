using System;
using DUR.Api.Entities;
using DUR.Api.Entities.Stuff;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Services.Queries
{
    public class ItemQueries : DatabaseBaseQueries<Item>
    {
        public ItemQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.ItemRepository();
        }
    }
}
