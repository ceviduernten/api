using System;
using System.Collections.Generic;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IGroupPresenter
    {
        List<GroupRM> GetAll();
    }
}
