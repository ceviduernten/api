using Autofac;
using DUR.Api.Entities;
using DUR.Api.Entities.Admin;
using DUR.Api.Entities.Stuff;
using DUR.Api.Entities.Easter;
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
            container.RegisterType<AppointmentQueries>().As<IQueries<Appointment>>();
            container.RegisterType<ContactQueries>().As<IQueries<Contact>>();
            container.RegisterType<BoxQueries>().As<IQueries<Box>>();
            container.RegisterType<UserQueries>().As<IQueries<User>>();
            container.RegisterType<ItemQueries>().As<IQueries<Item>>();
            container.RegisterType<StorageLocationQueries>().As<IQueries<StorageLocation>>();
            container.RegisterType<HuntCityQueries>().As<IQueries<HuntCity>>();
            container.RegisterType<HuntLocationQueries>().As<IQueries<HuntLocation>>();
            container.RegisterType<AppointmentResponseQueries>().As<IQueries<AppointmentResponse>>();
        }
    }
}
