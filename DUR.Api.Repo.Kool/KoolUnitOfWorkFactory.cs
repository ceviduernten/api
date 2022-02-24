using DUR.Api.Repo.Kool.Interfaces;
using DUR.Api.Settings;
using Microsoft.Extensions.Options;

namespace DUR.Api.Repo.Kool
{
    public class KoolUnitOfWorkFactory : IKoolUnitOfWorkFactory
    {
        private readonly GeneralSettings _settings;
        private readonly KoolInterfaceSettings _koolInterfaceSettings;
        private readonly IKoolUnitOfWork _koolUnitOfWork;

        public KoolUnitOfWorkFactory(IKoolUnitOfWork unitOfWork, IOptions<GeneralSettings> settings, IOptions<KoolInterfaceSettings> koolInterfaceSettings)
        {
            _koolUnitOfWork = unitOfWork;
            _koolInterfaceSettings = koolInterfaceSettings.Value;
            _settings = settings.Value;
        }

        public IKoolUnitOfWork Create()
        {
            return _koolUnitOfWork.GetCurrent(_koolInterfaceSettings, _settings);
        }

        public IKoolUnitOfWork New()
        {
            return new KoolUnitOfWork(true, _koolInterfaceSettings, _settings);
        }
    }
}
