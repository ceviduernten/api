using Autofac;
using DUR.Api.Entities;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;

namespace DUR.Api.Services
{
    public static class QueriesInjector
    {
        public static void RegisterModule(ContainerBuilder container)
        {
            // Queries
            container.RegisterType<GroupQueries>().As<IQueries<Group>>();
        }
    }
}
