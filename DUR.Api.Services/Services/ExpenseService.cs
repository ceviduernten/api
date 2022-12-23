using System.IO;
using DUR.Api.Entities.Financial;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Financial.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services.Services;

public class ExpenseService : DatabaseServiceBase<Expense>, IExpenseService
{
    private readonly IApplicationMailService _applicationMailService;
    private readonly IExpenseGenerator _expenseGenerator;

    public ExpenseService(IExpenseGenerator expenseGenerator, IApplicationMailService applicationMailService,
        IDatabaseUnitOfWorkFactory unitOfWorkFactory, IApplicationLogger logger) : base(logger)
    {
        _expenseGenerator = expenseGenerator;
        _applicationMailService = applicationMailService;
        databaseUnitOfWork = unitOfWorkFactory.Create();
        querier = new ExpenseQueries(databaseUnitOfWork);
    }


    public void AddExpense(Expense expense)
    {
        var pdfStream = new MemoryStream();
        _expenseGenerator.GenerateExpensePdf(expense, pdfStream);
        _applicationMailService.InformAboutExpense(expense);
    }
}