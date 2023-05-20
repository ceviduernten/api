using System.IO;
using System.Threading.Tasks;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DUR.Api.Web.Controllers;

[Authorize("Scouting")]
public class ExpensesController : DefaultController
{
    private readonly IExpensePresenter _expensePresenter;

    public ExpensesController(IExpensePresenter expensePresenter)
    {
        _expensePresenter = expensePresenter;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="resourceModel"></param>
    /// <returns></returns>
    [HttpPost, DisableRequestSizeLimit]
    public async Task<JsonResult> AddExpense([FromForm]ExpenseUploadRM resourceModel)
    {
        var fileStream = new MemoryStream();
        await resourceModel.File.CopyToAsync(fileStream);
        var expenseRm = JsonConvert.DeserializeObject<ExpenseRM>(resourceModel.Values);
        var success = await _expensePresenter.Add(expenseRm, fileStream);
        return Json(success ? new InfoJsonResult(200, "successfully added expense") : new InfoJsonResult(500, "Error on adding expense"));
    }
}