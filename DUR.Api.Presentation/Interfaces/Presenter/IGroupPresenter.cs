using System;
using System.Collections.Generic;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IGroupPresenter : IPresenter<GroupRM>
    {
        bool DeleteById(Guid id);
        bool Update(GroupRM entity);
        bool Add(GroupRM entity);
    }
}
