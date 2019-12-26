using System;
using Autofac;
using DUR.Api.Repo.Nextcloud.Interfaces;

namespace DUR.Api.Repo.Nextcloud
{
    public static class NextcloudRepositoryInjector
    {
        public static void RegisterModule(ContainerBuilder container)
        {
            // API
            container.RegisterType<NextcloudUnitOfWork>().As<INextcloudUnitOfWork>().InstancePerLifetimeScope();
            container.RegisterType<NextcloudUnitOfWorkFactory>().As<INextcloudUnitOfWorkFactory>();
        }
    }
}
