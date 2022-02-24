using DUR.Api.Settings;

namespace DUR.Api.Repo.Kool.Interfaces
{
    public interface IKoolUnitOfWork
    {
        IKoolUnitOfWork GetCurrent(KoolInterfaceSettings nextcloudInterfaceSettings, GeneralSettings settings);
        IKoolEventsRepo EventsRepo();
    }
}
