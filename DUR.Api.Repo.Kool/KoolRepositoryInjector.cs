using Autofac;
using DUR.Api.Repo.Kool.Interfaces;

namespace DUR.Api.Repo.Kool
{
    public static class KoolRepositoryInjector
    {
        public static void RegisterModule(ContainerBuilder container)
        {
            // API
            container.RegisterType<KoolUnitOfWork>().As<IKoolUnitOfWork>().InstancePerLifetimeScope();
            container.RegisterType<KoolUnitOfWorkFactory>().As<IKoolUnitOfWorkFactory>();
        }
    }
}
