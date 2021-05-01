using DUR.Api.Presentation.ResourceModel;
using System;
using System.Collections.Generic;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IBoxPresenter : IPresenter<BoxRM>
    {
        bool DeleteById(Guid id);
        bool Update(BoxRM entity);
        bool Add(BoxRM entity);
        List<BoxListRM> GetList();
    }
}
