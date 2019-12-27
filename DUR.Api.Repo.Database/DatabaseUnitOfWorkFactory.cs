using System;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Repo.Database
{
    public class DatabaseUnitOfWorkFactory : IDatabaseUnitOfWorkFactory
    {
        private readonly IDatabaseUnitOfWork _databaseUnitOfWork;

        public DatabaseUnitOfWorkFactory(IDatabaseUnitOfWork unitOfWork)
        {
            _databaseUnitOfWork = unitOfWork;
        }

        public IDatabaseUnitOfWork Create()
        {
            return _databaseUnitOfWork.GetCurrent();
        }

        public IDatabaseUnitOfWork New()
        {
            return new DatabaseUnitOfWork(true);
        }
    }
}
