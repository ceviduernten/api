using System;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
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
    private readonly IExpenseUploader _expenseUploader;

    public ExpenseService(IExpenseGenerator expenseGenerator, IApplicationMailService applicationMailService,
        IDatabaseUnitOfWorkFactory unitOfWorkFactory, IApplicationLogger logger, IExpenseUploader expenseUploader) : base(logger)
    {
        _expenseGenerator = expenseGenerator;
        _applicationMailService = applicationMailService;
        _expenseUploader = expenseUploader;
        databaseUnitOfWork = unitOfWorkFactory.Create();
        querier = new ExpenseQueries(databaseUnitOfWork);
    }


    public async Task AddExpense(Expense expense, MemoryStream expenseImageStream)
    {
        var pdfStream = new MemoryStream();
        var dbExpense = Add(expense);
        var fileName = BuildFileName(dbExpense);
        _expenseGenerator.GenerateExpensePdf(dbExpense, pdfStream, expenseImageStream);
        await _expenseUploader.UploadExpense(fileName, pdfStream);
        pdfStream.Position = 0;
        var attachment = new Attachment(pdfStream, new System.Net.Mime.ContentType("application/pdf"));
        attachment.ContentDisposition!.FileName = fileName;
        _applicationMailService.InformAboutExpense(expense, attachment);
    }

    private static string BuildFileName(Expense expense)
    {
        return expense.Id.ToString("N") + "_" + expense.LastName + "_" + expense.FirstName + "_" + DateTime.Now.ToShortDateString() + ".pdf";
    }
}