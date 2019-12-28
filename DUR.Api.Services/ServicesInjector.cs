﻿using System;
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
            container.RegisterType<GroupService>().As<IGroupService>();
            container.RegisterType<AppointmentService>().As<IAppointmentService>();
            container.RegisterType<ContactService>().As<IContactService>();
        }
    }
}
