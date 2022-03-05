using System;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Interfaces.Presenter;

public interface IHuntCityPresenter : IPresenter<HuntCityRM>
{
    bool DeleteById(Guid id);
    bool Update(HuntCityRM entity);
    bool Add(HuntCityRM entity);
}