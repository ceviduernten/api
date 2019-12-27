using System;
using System.Collections.Generic;
using System.Linq;

namespace DUR.Api.Services.Interfaces
{
    public interface IDatabaseService<T> where T : class
    {
        T Add(T entity, bool saveToDb);
        T Add(T entity);

        T Update(T entity, bool saveToDb);
        T Update(T entity);

        void Delete(T entity, bool saveToDb, bool removeFromDb);
        void Delete(T entity, bool removeFromDb = false);

        bool DeleteById(int id, bool saveToDb, bool removeFromDb = false);
        bool DeleteById(int id, bool removeFromDb = false);

        bool DeleteById(Guid id, bool saveToDb, bool removeFromDb = false);
        bool DeleteById(Guid id, bool removeFromDb = false);

        T GetById(int id);
        T GetById(Guid id);

        List<T> GetAll();

        List<T> GetAllIncludingDeleted();

        IQueryable<T> GetAllQueryable();
    }
}
