using Autofac;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.Presenter;

namespace DUR.Api.Presentation
{
    public static class PresenterInjector
    {
        public static void RegisterModule(ContainerBuilder container)
        {
            container.RegisterType<EventPresenter>().As<IEventPresenter>();
            container.RegisterType<GroupPresenter>().As<IGroupPresenter>();
            container.RegisterType<AppointmentPresenter>().As<IAppointmentPresenter>();
            container.RegisterType<ContactPresenter>().As<IContactPresenter>();
            container.RegisterType<StorageLocationPresenter>().As<IStorageLocationPresenter>();
            container.RegisterType<BoxPresenter>().As<IBoxPresenter>();
            container.RegisterType<ItemPresenter>().As<IItemPresenter>();
            container.RegisterType<ExportPresenter>().As<IExportPresenter>();
            container.RegisterType<UserPresenter>().As<IUserPresenter>();
        }
    }
}
