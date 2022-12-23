using DUR.Api.Entities.Financial;

namespace DUR.Api.Services.Interfaces;

public interface IExpenseService : IDatabaseService<Expense>
{
    void AddExpense(Expense expense);
}