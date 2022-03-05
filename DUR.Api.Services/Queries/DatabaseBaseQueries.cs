using System;
using System.Linq;
using DUR.Api.Entities.Default;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Services.Queries;

public abstract class DatabaseBaseQueries<T> : IQueries<T> where T : Base
{
    protected readonly IDatabaseUnitOfWork _unitOfWork;
    protected IRepository<T> _repository;

    protected DatabaseBaseQueries(IDatabaseUnitOfWork databaseUnitOfWork)
    {
        _unitOfWork = databaseUnitOfWork;
    }

    public void Add(T entity)
    {
        _repository.Add(entity);
    }

    public void Delete(T entity, bool removeFromDatabase)
    {
        _repository.Delete(entity, removeFromDatabase);
    }

    public void DeleteById(int id, bool removeFromDatabase)
    {
        _repository.DeleteById(id, removeFromDatabase);
    }

    public void DeleteById(Guid id, bool removeFromDatabase)
    {
        _repository.DeleteById(id, removeFromDatabase);
    }

    public IQueryable<T> GetAll()
    {
        return _repository.GetAll();
    }

    public IQueryable<T> GetAllIncludingDeleted()
    {
        return _repository.GetAllIncludingDeleted();
    }

    public T GetById(int id)
    {
        return _repository.GetById(id);
    }

    public T GetById(Guid id)
    {
        return _repository.GetById(id);
    }

    public void Update(T entity)
    {
        _repository.Update(entity);
    }
}