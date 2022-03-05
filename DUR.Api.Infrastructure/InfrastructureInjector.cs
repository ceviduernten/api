using Autofac;
using DUR.Api.Infrastructure.Interfaces;

namespace DUR.Api.Infrastructure;

public static class InfrastructureInjector
{
    public static void RegisterModule(ContainerBuilder container)
    {
        container.RegisterType<ApplicationLogger>().As<IApplicationLogger>().SingleInstance();
    }
}