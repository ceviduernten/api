using DUR.Api.Presentation.ResourceModel;
using System;
using System.Collections.Generic;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IHuntLocationPresenter : IPresenter<HuntLocationRM>
    {
        bool DeleteById(Guid id);
        bool Update(HuntLocationRM entity);
        bool Found(Guid id);
        bool Add(HuntLocationRM entity);
        List<HuntLocationListRM> GetList();
        List<HuntLocationListRM> GetAllActiveList();
        bool ActivateAllLocations();
    }
}
