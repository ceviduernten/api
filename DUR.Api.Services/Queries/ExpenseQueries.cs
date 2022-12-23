using DUR.Api.Entities.Financial;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Services.Queries;

public class ExpenseQueries : DatabaseBaseQueries<Expense>
{
    public ExpenseQueries(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _repository = unitOfWork.ExpenseRepository();
    }
}