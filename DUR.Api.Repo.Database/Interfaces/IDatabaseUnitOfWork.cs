using System;
using DUR.Api.Entities;
using DUR.Api.Entities.Admin;
using DUR.Api.Entities.Easter;
using DUR.Api.Entities.Stuff;

namespace DUR.Api.Repo.Database.Interfaces;

public interface IDatabaseUnitOfWork
{
    Guid UniqueId { get; set; }
    void Save();
    IDatabaseUnitOfWork GetCurrent();
    void RefreshContext();
    void Refresh<T>(T domainObj) where T : class;
    void Detach<T>(T domainObj) where T : class;
    void Rollback();

    IRepository<Group> GroupRepository();
    IRepository<Appointment> AppointmentRepository();
    IRepository<Contact> ContactRepository();
    IRepository<Box> BoxRepository();
    IRepository<Item> ItemRepository();
    IRepository<StorageLocation> StorageLocationRepository();
    IRepository<User> UserRepository();
    IRepository<HuntCity> HuntCityRepository();
    IRepository<HuntLocation> HuntLocationRepository();
    IRepository<AppointmentResponse> AppointmentResponseRepository();
}