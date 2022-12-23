using System.IO;
using System.Threading.Tasks;
using DUR.Api.Entities.Financial;

namespace DUR.Api.Services.Interfaces;

public interface IExpenseService : IDatabaseService<Expense>
{
    Task AddExpense(Expense expense, MemoryStream expenseImageStream);
}