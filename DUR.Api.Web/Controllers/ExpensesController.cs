using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Controllers;

[Authorize("Scouting")]
public class ExpensesController : DefaultController
{
    private readonly IExpensePresenter _expensePresenter;

    public ExpensesController(IExpensePresenter expensePresenter)
    {
        _expensePresenter = expensePresenter;
    }
    
    public JsonResult AddExpense(ExpenseRM expense)
    {
        var success = _expensePresenter.Add(expense);
        if (success)
            return Json(new InfoJsonResult(200, "successfully added expense"));
        return Json(new InfoJsonResult(500, "Error on adding expense"));
    }
}