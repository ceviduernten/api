using System;
using System.Linq;
using DUR.Api.Entities;
using DUR.Api.Entities.Stuff;
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
        private Repository<Appointment> _appointmentRepository;
        private Repository<Contact> _contactRepository;
        private Repository<Box> _boxRepository;
        private Repository<Item> _itemRepository;
        private Repository<StorageLocation> _storageLocationRepoistory;

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
            _dataContext ??= (_dataContext = new RepositoryContext(_databaseOptions));
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
            _groupRepository ??= new Repository<Group>(_dataContext);
            return _groupRepository;
        }

        public IRepository<Appointment> AppointmentRepository()
        {
            _appointmentRepository ??= new Repository<Appointment>(_dataContext);
            return _appointmentRepository;
        }

        public IRepository<Contact> ContactRepository()
        {
            _contactRepository ??= new Repository<Contact>(_dataContext);
            return _contactRepository;
        }

        public IRepository<Box> BoxRepository()
        {
            _boxRepository ??= new Repository<Box>(_dataContext);
            return _boxRepository;
        }

        public IRepository<Item> ItemRepository()
        {
            _itemRepository ??= new Repository<Item>(_dataContext);
            return _itemRepository;
        }

        public IRepository<StorageLocation> StorageLocationRepository()
        {
            _storageLocationRepoistory ??= new Repository<StorageLocation>(_dataContext);
            return _storageLocationRepoistory;
        }
    }
}
