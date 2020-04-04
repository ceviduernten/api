using System;
using System.Collections.Generic;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IBoxPresenter : IPresenter<BoxRM>
    {
        bool DeleteById(Guid id);
        bool Update(BoxRM entity);
        bool Add(BoxRM entity);
        new List<BoxListRM> GetAll();
    }
}
