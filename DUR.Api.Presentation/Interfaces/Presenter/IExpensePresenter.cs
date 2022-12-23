using System.IO;
using System.Threading.Tasks;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Interfaces.Presenter;

public interface IExpensePresenter : IPresenter<ExpenseRM>
{
    Task<bool> Add(ExpenseRM entity, MemoryStream expenseImageStream);
}