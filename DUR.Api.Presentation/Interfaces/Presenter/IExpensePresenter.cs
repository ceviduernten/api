using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Interfaces.Presenter;

public interface IExpensePresenter : IPresenter<ExpenseRM>
{
    bool Add(ExpenseRM entity);
}