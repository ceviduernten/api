using System;
using System.Linq;
using System.Linq.Expressions;
using DUR.Api.Entities.Default;
using DUR.Api.Repo.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DUR.Api.Repo.Database;

public class Repository<T> : DbSetBase<T>, IRepository<T> where T : Base
{
    public Repository(RepositoryContext dataContext) : base(dataContext)
    {
    }

    public void Add(T entity)
    {
        entity.CreateDate = DateTime.Now;
        entity.ModDate = DateTime.Now;
        DbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        entity.Deleted = true;
        entity.ModDate = DateTime.Now;
        DbSet.Attach(entity);
        DataContext.Entry(entity).State = EntityState.Modified;
        DataContext.Entry(entity).Property(x => x.CreateDate).IsModified = false;
    }

    public void Delete(T entity, bool removeFromDb)
    {
        if (removeFromDb)
        {
            DbSet.Remove(entity);
            DataContext.Entry(entity).State = EntityState.Deleted;
        }
        else
        {
            Delete(entity);
        }
    }

    public void DeleteById(int id, bool removeFromDb)
    {
        var entity = GetById(id);
        Delete(entity, removeFromDb);
    }

    public void DeleteById(int id)
    {
        DeleteById(id, false);
    }

    public void DeleteById(Guid id, bool removeFromDb)
    {
        var entity = GetById(id);
        Delete(entity, removeFromDb);
    }

    public void DeleteById(Guid id)
    {
        DeleteById(id, false);
    }

    public IQueryable<T> GetAll()
    {
        var all = DbSet.Include(DataContext.GetIncludePaths(typeof(T))).Where(o => !o.Deleted);
        return all;
    }

    public IQueryable<T> GetAllIncludingDeleted()
    {
        var all = DbSet;
        return all;
    }

    public T GetById(int id)
    {
        if (id > 0)
        {
            var primaryKey = DataContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
            var parameter = Expression.Parameter(typeof(T), "e");
            var predicate = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(Expression.PropertyOrField(parameter, primaryKey.Single().Name),
                    Expression.Constant(id)), parameter);

            var query = DbSet.AsQueryable();
            query = query.Include(DataContext.GetIncludePaths(typeof(T)));
            var entity = query.FirstOrDefault(predicate);
            return !entity.Deleted ? entity : null;
        }

        return default;
    }

    public T GetById(Guid id)
    {
        if (!string.IsNullOrWhiteSpace(id.ToString()))
        {
            var primaryKey = DataContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
            var parameter = Expression.Parameter(typeof(T), "e");
            var predicate = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(Expression.PropertyOrField(parameter, primaryKey.Single().Name),
                    Expression.Constant(id)), parameter);

            var query = DbSet.AsQueryable();
            query = query.Include(DataContext.GetIncludePaths(typeof(T)));
            var entity = query.FirstOrDefault(predicate);
            return !entity.Deleted ? entity : null;
        }

        return default;
    }

    public void Update(T entity)
    {
        entity.ModDate = DateTime.Now;
        DbSet.Attach(entity);
        DataContext.Entry(entity).State = EntityState.Modified;
        DataContext.Entry(entity).Property(x => x.Deleted).IsModified = false;
        DataContext.Entry(entity).Property(x => x.CreateDate).IsModified = false;
    }
}