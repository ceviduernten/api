using System;
using System.Linq;

namespace DUR.Api.Services.Interfaces
{
    public interface IQueries<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllIncludingDeleted();
        T GetById(int id);
        T GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity, bool removeFromDatabase);
        void DeleteById(int id, bool removeFromDatabase);
        void DeleteById(Guid id, bool removeFromDatabase);
    }
}
