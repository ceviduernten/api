using DUR.Api.Settings;

namespace DUR.Api.Repo.Nextcloud.Interfaces;

public interface INextcloudUnitOfWork
{
    INextcloudUnitOfWork GetCurrent(NextcloudInterfaceSettings nextcloudInterfaceSettings, GeneralSettings settings);
    IEventsRepo EventsRepo();
}