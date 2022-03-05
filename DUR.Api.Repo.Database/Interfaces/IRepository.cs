using System;
using System.Linq;

namespace DUR.Api.Repo.Database.Interfaces;

public interface IRepository<T> : IDbSetBase<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Delete(T entity, bool removeFromDb);
    void DeleteById(int id, bool removeFromDb);
    void DeleteById(Guid id, bool removeFromDb);
    void DeleteById(int id);
    void DeleteById(Guid id);
    T GetById(int id);
    T GetById(Guid id);
    IQueryable<T> GetAll();
    IQueryable<T> GetAllIncludingDeleted();
}