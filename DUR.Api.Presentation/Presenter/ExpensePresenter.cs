﻿using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DUR.Api.Entities.Financial;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Presentation.Presenter;

public class ExpensePresenter : BasePresenter<ExpenseRM, Expense>, IExpensePresenter
{
    private readonly IExpenseService _expenseService;
    private readonly IMapper _mapper;

    public ExpensePresenter(IMapper mapper, IExpenseService expenseService) : base(
        expenseService, mapper)
    {
        _expenseService = expenseService;
        _mapper = mapper;
    }

    public async Task<bool> Add(ExpenseRM entity, MemoryStream expenseImageStream)
    {
        var model = _mapper.Map<Expense>(entity);
        await _expenseService.AddExpense(model, expenseImageStream);
        return true;
    }

    public override ExpenseRM GetBlank()
    {
        return new ExpenseRM();
    }

    public override void UpdateBlank(ExpenseRM entity)
    {
        // NOTHING TO DO HERE
    }
}