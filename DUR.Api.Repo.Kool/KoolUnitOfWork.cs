using DUR.Api.Repo.Kool.Interfaces;
using DUR.Api.Repo.Kool.Repositories;
using DUR.Api.Settings;
using System;

namespace DUR.Api.Repo.Kool
{
    public class KoolUnitOfWork : IDisposable, IKoolUnitOfWork
    {
        private IKoolApi _api;
        private IKoolEventsRepo _eventsRepo;
        private GeneralSettings _settings;
        private bool disposed = false;

        public KoolUnitOfWork(bool isNew, KoolInterfaceSettings koolInterfaceSettings, GeneralSettings settings)
        {
            if (isNew)
            {
                _settings = settings;
                _api = new KoolApi(koolInterfaceSettings);
            }
        }

        public KoolUnitOfWork()
        {
            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {

                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IKoolUnitOfWork GetCurrent(KoolInterfaceSettings koolInterfaceSettings, GeneralSettings settings)
        {
            _settings = _settings ?? (_settings = settings);
            _api = _api ?? (_api = new KoolApi(koolInterfaceSettings));
            return this;
        }

        public IKoolEventsRepo EventsRepo()
        {
            _eventsRepo = _eventsRepo ?? new KoolEventsRepo(_api, _settings);
            return _eventsRepo;
        }
    }
}
