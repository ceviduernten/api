using System;
using System.Collections.Generic;
using System.Linq;
using DUR.Api.Entities.Default;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Services.Services;

public abstract class DatabaseServiceBase<T> : IDatabaseService<T> where T : Base
{
    private readonly IApplicationLogger _logger;
    protected IDatabaseUnitOfWork databaseUnitOfWork;
    protected IQueries<T> querier;

    protected DatabaseServiceBase(IApplicationLogger logger)
    {
        _logger = logger;
    }

    public T Add(T entity, bool saveToDb)
    {
        try
        {
            querier.Add(entity);
            if (saveToDb)
            {
                databaseUnitOfWork.Save();
                _logger.LogInformation<T>("Added (DatabaseServiceBase)");
                return entity;
            }
        }
        catch (Exception e)
        {
            _logger.LogError<T>(e, "Error adding (DatabaseServiceBase)");
        }

        return null;
    }

    public T Add(T entity)
    {
        return Add(entity, true);
    }

    public void Delete(T entity, bool saveToDb, bool removeFromDb)
    {
        try
        {
            querier.Delete(entity, removeFromDb);
            if (saveToDb)
            {
                databaseUnitOfWork.Save();
                _logger.LogInformation<T>("Deleted (DatabaseServiceBase)");
            }
        }
        catch (Exception e)
        {
            _logger.LogError<T>(e, "Error on deleting (DatabaseServiceBase)");
        }
    }

    public void Delete(T entity, bool removeFromDb = false)
    {
        Delete(entity, true, removeFromDb);
    }

    public bool DeleteById(int id, bool saveToDb, bool removeFromDb = false)
    {
        try
        {
            querier.DeleteById(id, removeFromDb);
            if (saveToDb)
            {
                databaseUnitOfWork.Save();
                _logger.LogInformation<T>("Deleted By Id (DatabaseServiceBase)");
            }
        }
        catch (Exception e)
        {
            databaseUnitOfWork.Rollback();
            _logger.LogError<T>(e, "Error on deleting by id (DatabaseServiceBase)");
            return false;
        }

        return true;
    }

    public bool DeleteById(int id, bool removeFromDb = false)
    {
        return DeleteById(id, true, removeFromDb);
    }

    public bool DeleteById(Guid id, bool saveToDb, bool removeFromDb = false)
    {
        try
        {
            querier.DeleteById(id, removeFromDb);
            if (saveToDb)
            {
                databaseUnitOfWork.Save();
                _logger.LogInformation<T>("Deleted By Guid (DatabaseServiceBase)");
            }
        }
        catch (Exception e)
        {
            databaseUnitOfWork.Rollback();
            _logger.LogError<T>(e, "Error on deleting by guid (DatabaseServiceBase)");
            return false;
        }

        return true;
    }

    public bool DeleteById(Guid id, bool removeFromDb = false)
    {
        return DeleteById(id, true, removeFromDb);
    }

    public List<T> GetAll()
    {
        return GetAllQueryable().ToList();
    }

    public List<T> GetAllIncludingDeleted()
    {
        return GetAllIncludingDeletedQueryable().ToList();
    }

    public IQueryable<T> GetAllQueryable()
    {
        try
        {
            return querier.GetAll();
        }
        catch (Exception e)
        {
            _logger.LogError<T>(e, "error getting all queryable from database");
            return Enumerable.Empty<T>().AsQueryable();
        }
    }

    public T GetById(int id)
    {
        try
        {
            return querier.GetById(id);
        }
        catch (Exception e)
        {
            _logger.LogError<T>(e, "error on getting by id");
            return null;
        }
    }

    public T GetById(Guid id)
    {
        try
        {
            return querier.GetById(id);
        }
        catch (Exception e)
        {
            _logger.LogError<T>(e, "error on getting by guid");
            return null;
        }
    }

    public T Update(T entity, bool saveToDb)
    {
        try
        {
            querier.Update(entity);
            if (saveToDb) databaseUnitOfWork.Save();
            return entity;
        }
        catch (Exception e)
        {
            _logger.LogError<T>(e, "error on updating");
        }

        return null;
    }

    public T Update(T entity)
    {
        return Update(entity, true);
    }

    private IQueryable<T> GetAllIncludingDeletedQueryable()
    {
        try
        {
            return querier.GetAllIncludingDeleted();
        }
        catch (Exception e)
        {
            _logger.LogError<T>(e, "error getting all queryable including deleted from database");
            return Enumerable.Empty<T>().AsQueryable();
        }
    }
}