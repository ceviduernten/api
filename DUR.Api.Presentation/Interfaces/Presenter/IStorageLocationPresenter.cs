using System;
using System.Collections.Generic;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IStorageLocationPresenter : IPresenter<StorageLocationRM>
    {
        bool DeleteById(Guid id);
        bool Update(StorageLocationRM entity);
        bool Add(StorageLocationRM entity);
    }
}
