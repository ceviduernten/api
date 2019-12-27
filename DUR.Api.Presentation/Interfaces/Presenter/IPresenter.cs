using System;
using System.Collections.Generic;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IPresenter<T>
    {
        T GetById(int id);
        T GetById(Guid id);
        List<T> GetAll();
        void UpdateBlank(T entity);
        T GetBlank();
    }
}
