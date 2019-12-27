using System;
namespace DUR.Api.Repo.Database.Interfaces
{
    public interface IDatabaseUnitOfWorkFactory
    {
        IDatabaseUnitOfWork Create();
        IDatabaseUnitOfWork New();
    }
}
