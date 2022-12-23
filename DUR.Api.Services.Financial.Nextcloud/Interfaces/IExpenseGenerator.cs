using System.IO;
using DUR.Api.Entities.Financial;

namespace DUR.Api.Services.Financial.Interfaces;

public interface IExpenseGenerator
{
    void GenerateExpensePdf(Expense expense, MemoryStream stream);
}