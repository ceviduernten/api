using System;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Entities.Default;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DUR.Api.Repo.Database
{
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
            var all = DbSet.Where(o => !o.Deleted);
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
                var entity = DbSet.Find(id);
                return !entity.Deleted ? entity : null;
            }
            else
            {
                return default(T);
            }
        }

        public T GetById(Guid id)
        {
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                var entity = DbSet.Find(id);
                return !entity.Deleted ? entity : null;
            }
            else
            {
                return default(T);
            }
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
}
