using System;
using DUR.Api.Repo.Nextcloud.Interfaces;
using DUR.Api.Repo.Nextcloud.Repositories;
using DUR.Api.Settings;

namespace DUR.Api.Repo.Nextcloud;

public class NextcloudUnitOfWork : IDisposable, INextcloudUnitOfWork
{
    private INextcloudApi _api;
    private IEventsRepo _eventsRepo;
    private GeneralSettings _settings;
    private bool disposed;

    public NextcloudUnitOfWork(bool isNew, NextcloudInterfaceSettings nextcloudInterfaceSettings,
        GeneralSettings settings)
    {
        if (isNew)
        {
            _settings = settings;
            _api = new NextcloudApi(nextcloudInterfaceSettings);
        }
    }

    public NextcloudUnitOfWork()
    {
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public INextcloudUnitOfWork GetCurrent(NextcloudInterfaceSettings nextcloudInterfaceSettings,
        GeneralSettings settings)
    {
        _settings = _settings ?? (_settings = settings);
        _api = _api ?? (_api = new NextcloudApi(nextcloudInterfaceSettings));
        return this;
    }

    public IEventsRepo EventsRepo()
    {
        _eventsRepo = _eventsRepo ?? new EventsRepo(_api, _settings);
        return _eventsRepo;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
            if (disposing)
            {
            }

        disposed = true;
    }
}