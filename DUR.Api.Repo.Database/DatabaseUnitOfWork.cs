﻿using System;
using System.Linq;
using DUR.Api.Entities.Default;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DUR.Api.Repo.Database
{
    public class DatabaseUnitOfWork : Disposable, IDatabaseUnitOfWork
    {
        private RepositoryContext _dataContext;
        private readonly IOptions<DatabaseOptions> _databaseOptions;

        private Repository<Group> _groupRepository;

        public DatabaseUnitOfWork(IOptions<DatabaseOptions> options)
        {
            UniqueId = Guid.NewGuid();
            _databaseOptions = options;
        }

        public DatabaseUnitOfWork(bool IsNew)
        {
            if (IsNew)
            {
                _dataContext = new RepositoryContext(_databaseOptions);
            }
        }

        public Guid UniqueId { get; set; }

        public void Detach<T>(T domainObj) where T : class
        {
            _dataContext.Entry<T>(domainObj).State = EntityState.Detached;
        }

        public IDatabaseUnitOfWork GetCurrent()
        {
            _dataContext = _dataContext ?? (_dataContext = new RepositoryContext(_databaseOptions));
            return this;
        }

        public void Refresh<T>(T domainObj) where T : class
        {
            _dataContext.Entry<T>(domainObj).Reload();
        }

        public void RefreshContext()
        {
            var refreshableObjects = _dataContext.ChangeTracker.Entries().Select(c => c.Entity).ToList();
            foreach (var o in refreshableObjects)
            {
                _dataContext.Entry(o).Reload();
            }
        }

        public void Rollback()
        {
            _dataContext.Database.CurrentTransaction.Rollback();
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        public IRepository<Group> GroupRepository()
        {
            _groupRepository = _groupRepository ?? new Repository<Group>(_dataContext);
            return _groupRepository;
        }

    }
}
