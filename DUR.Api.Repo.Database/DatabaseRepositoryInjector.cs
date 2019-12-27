using System;
using Autofac;
using DUR.Api.Repo.Database.Interfaces;

namespace DUR.Api.Repo.Database
{
    public static class DatabaseRepositoryInjector
    {
        public static void RegisterModule(ContainerBuilder container)
        {
            container.RegisterType<DatabaseUnitOfWork>().As<IDatabaseUnitOfWork>().InstancePerLifetimeScope();
            container.RegisterType<DatabaseUnitOfWorkFactory>().As<IDatabaseUnitOfWorkFactory>();
        }
    }
}
