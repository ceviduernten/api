using System;
using System.Collections.Generic;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IUserPresenter : IPresenter<UserRM>
    {
        bool DeleteById(Guid id);
        bool Update(UserRM entity);
        bool Add(UserRM entity);
        UserRM ValidateUser(UserRM entity);
    }
}
