using System.IO;
using DUR.Api.Entities.Financial;
using DUR.Api.Services.Financial.Documents;
using DUR.Api.Services.Financial.Interfaces;
using QuestPDF.Fluent;

namespace DUR.Api.Services.Financial.Services;

public class ExpenseGenerator : IExpenseGenerator
{
    public void GenerateExpensePdf(Expense expense, MemoryStream outputStream, MemoryStream expenseImageStream)
    {
        var document = new ExpenseDocument(expense, expenseImageStream);
        document.GeneratePdf(outputStream);
        expenseImageStream.Close();
    }
}