using DUR.Api.Presentation.ResourceModel;
using System;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IStorageLocationPresenter : IPresenter<StorageLocationRM>
    {
        bool DeleteById(Guid id);
        bool Update(StorageLocationRM entity);
        bool Add(StorageLocationRM entity);
    }
}
