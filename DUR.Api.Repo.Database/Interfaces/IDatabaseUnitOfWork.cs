using System;
using DUR.Api.Entities;

namespace DUR.Api.Repo.Database.Interfaces
{
    public interface IDatabaseUnitOfWork
    {
        void Save();
        IDatabaseUnitOfWork GetCurrent();
        void RefreshContext();
        void Refresh<T>(T domainObj) where T : class;
        void Detach<T>(T domainObj) where T : class;
        void Rollback();
        Guid UniqueId { get; set; }
        IRepository<Group> GroupRepository();
        IRepository<Appointment> AppointmentRepository();
    }
}
