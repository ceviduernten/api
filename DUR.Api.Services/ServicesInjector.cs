using System;
using Autofac;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Services;

namespace DUR.Api.Services
{
    public static class ServicesInjector
    {
        public static void RegisterModule(ContainerBuilder container)
        {
            container.RegisterType<EventService>().As<IEventService>();
        }
    }
}
